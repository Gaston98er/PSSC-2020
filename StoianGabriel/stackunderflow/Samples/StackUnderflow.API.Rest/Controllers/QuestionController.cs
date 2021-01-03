using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question")]
    public class QuestionController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateQuestionAsync()
        {
            
        }
    }
}
