using System;

namespace AsteriskManager.Exceptions
{
    [Serializable()]
    public class AmiException : System.Exception
    {
        public AmiException() : base() { }
        public AmiException(string message) : base(message) { }
        public AmiException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected AmiException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }

    }
    [Serializable()]
    public class AmiTimeOutException : System.Exception
    {
        public AmiTimeOutException() : base() { }
        public AmiTimeOutException(string message) : base(message) { }
        public AmiTimeOutException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected AmiTimeOutException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }

    }
}
