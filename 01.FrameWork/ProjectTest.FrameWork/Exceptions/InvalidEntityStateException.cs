using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.FrameWork.Exceptions
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(object entity, string message)
        : base(string.Format("Invalid User", entity.GetType().Name, message))
        {
        }
    }
}
