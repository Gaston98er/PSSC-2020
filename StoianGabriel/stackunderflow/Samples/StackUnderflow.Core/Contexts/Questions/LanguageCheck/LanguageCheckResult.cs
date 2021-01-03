using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.LanguageCheck
{
    [AsChoice]
    public static partial class LanguageCheckResult
    {
        public interface ILanguageCheckResult { }

        public class CheckSucceeded : ILanguageCheckResult
        {
            public string TextToCheck { get; }
            
            public CheckSucceeded(string textToCheck)
            {
                this.TextToCheck = textToCheck;
            }
        }

        public class CheckFailed : ILanguageCheckResult
        {
            public string ErrorMsg { get; }
            
            public CheckFailed(string errorMsg)
            {
                this.ErrorMsg = errorMsg;
            }
        }
    }
}
