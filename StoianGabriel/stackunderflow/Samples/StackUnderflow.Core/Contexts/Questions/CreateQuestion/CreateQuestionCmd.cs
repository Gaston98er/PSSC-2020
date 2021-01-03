using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class CreateQuestionCmd
    {
        [Required]
        public string QuestionTitle { get; private set; }
        [Required]
        public string QuestionBody { get; private set; }
        [Required]
        public string QuestionTags { get; private set; }

        public CreateQuestionCmd(string questionTitle, string questionBody, string questionTags)
        {
            this.QuestionTitle = questionTitle;
            this.QuestionBody = questionBody;
            this.QuestionTags = questionTags;
        }
    }
}
