﻿namespace SecurityTest.Application.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message)
        {
            throw new Exception(message);
        }
    }
}