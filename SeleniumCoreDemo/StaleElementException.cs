using System;
using System.Runtime.Serialization;

namespace SeleniumCoreDemo
{
    [Serializable]
    internal class StaleElementException : Exception
    {
        public StaleElementException()
        {
        }

        public StaleElementException(string message) : base(message)
        {
        }

        public StaleElementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StaleElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}