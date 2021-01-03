using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }
        public class QuestionCreated : ICreateQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string QuestionTitle { get; private set; }
            public string QuestionBody { get; private set; }
            public string QuestionTags { get; private set; }

            public QuestionCreated(Guid questionId, string questionTitle, string questionBody, string questionTags)
            {
                this.QuestionId = questionId;
                this.QuestionTitle = questionTitle;
                this.QuestionBody = questionBody;
                this.QuestionTags = questionTags;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string ErrorMsg { get; }
            
            public QuestionNotCreated(string errorMsg)
            {
                this.ErrorMsg = errorMsg;
            }
        }
    }
}
