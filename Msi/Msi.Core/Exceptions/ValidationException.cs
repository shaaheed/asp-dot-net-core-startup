﻿namespace Msi.Core
{
    public class ValidationException : BusinessExceptionBase
    {
        public ValidationException(string message) : base(400, message)
        { 
        }
    }
}
