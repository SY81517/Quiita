using System;
using System.Runtime.Serialization;

namespace JsonCallback
{
    public class NewtonCallBackAttribute : INewtonCallBackAttribute
    {
        public string Message { get; set; }

        [OnDeserialized]
        public void CallBackMethod(StreamingContext context)
        {
            Message = "Deserialized";
        }
    }
}