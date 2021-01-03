using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.LanguageCheck;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.LanguageCheck.LanguageCheckResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionContext
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd) =>
            NewPort<CreateQuestionCmd, ICreateQuestionResult>(createQuestionCmd);
        public static Port<ILanguageCheckResult> LanguageCheck(LanguageCheckCmd languageCheckCmd) =>
            NewPort<LanguageCheckCmd, ILanguageCheckResult>(languageCheckCmd);
    }
}
