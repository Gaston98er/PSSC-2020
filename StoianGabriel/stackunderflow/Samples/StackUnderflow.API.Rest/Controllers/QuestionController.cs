using Access.Primitives.EFCore;
using Access.Primitives.IO;
using GrainInterfaces;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orleans;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Question.SendAckToOwner;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [Route("question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;
        private readonly IClusterClient _client;

        public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext, IClusterClient client)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _client = client;
        }

        [HttpPost("createQuestion")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd cmd)
        {
            QuestionWriteContext ctx = new QuestionWriteContext(new EFList<Post>(_dbContext.Post));

            var dependencies = new QuestionDependencies();
            dependencies.QuestionEmail = SendEmail;

            var exp = from CreateQuestionResult in QuestionContext.CreateQuestion(cmd)
                      select CreateQuestionResult;
            var r = await _interpreter.Interpret(exp, ctx, dependencies);
            _dbContext.SaveChanges();

            return r.Match(
                created => (IActionResult)Ok("Question posted"),
                notCreated => StatusCode(StatusCodes.Status500InternalServerError, "Question could not be posted.")
                );
        }

        private TryAsync<SendConfirmationAck> SendEmail(SendConfirmationLetter letter)
        => async () =>
        {
            var emialSender = _client.GetGrain<IEmailSender>(0);
            await emialSender.SendEmailAsync(letter.ConfirmationMsg);
            return new SendConfirmationAck(Guid.NewGuid().ToString());
        };
    }
}
