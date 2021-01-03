using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.LanguageCheck
{
    public class LanguageCheckCmd
    {
        [Required]
        public string TextToCheck { get; }

        public LanguageCheckCmd(string textToCheck)
        {
            this.TextToCheck = textToCheck;
        }
    }
}
