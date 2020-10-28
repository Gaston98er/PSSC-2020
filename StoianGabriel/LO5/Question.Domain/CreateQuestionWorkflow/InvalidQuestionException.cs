using System;

namespace Question.Domain.CreateQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException()
        { }

        public InvalidQuestionException(string title) : base ($"\"{question}\" is an invalid question.")
        { }
    }
}