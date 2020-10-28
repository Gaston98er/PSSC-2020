using System;

namespace Profile.Domain.CreateProfileWorkflow
{
    [Serializable]
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string email) : base($"\"{email}\" is an invalid e-mail.")
        {
        }

    }
}
