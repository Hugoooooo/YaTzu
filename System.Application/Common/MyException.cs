using System;
using System.Runtime.Serialization;

namespace System.Application.Common
{
    class MyException : Exception, ISerializable
    {
        public MyException()
            : base("")
        {
        }

        public MyException(string message)
            : base(message)
        {
        }

        public MyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
