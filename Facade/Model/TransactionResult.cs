using Domain;
using System;

namespace Facade
{
    public class TransactionResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public void SetStatusSucceeded(string messageDescription = null)
        {
            SetStatus(true, messageDescription);
        }
        public void SetStatusValidationException(string messageDescription = null)
        {
            SetStatus(false, messageDescription);
        }
        public void SetStatusUnhandledException(Exception exception)
        {
            var messageDescription = exception.CreateExceptionString();
            SetStatus(false, messageDescription);
        }

        private void SetStatus(bool isSuccess, string messageDescription = null)
        {
            IsSuccess = isSuccess;
            Message = messageDescription;
        }
    }

    public class TransactionResult<T> : TransactionResult
    {
        public T Response { get; set; }
    }
}
