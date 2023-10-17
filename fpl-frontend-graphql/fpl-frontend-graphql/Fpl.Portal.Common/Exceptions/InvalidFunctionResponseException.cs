using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Exceptions
{
    [Serializable]
    public class InvalidFunctionResponseException : Exception
    {
        protected InvalidFunctionResponseException(SerializationInfo info,
            StreamingContext context)
            : base(info, context) 
        { 
        }

        public InvalidFunctionResponseException() 
        { 
        }

        public InvalidFunctionResponseException(string functionName,
            HttpStatusCode? httpStatusCode)
            : base($"Fpl API returned invalid response. Function: {functionName}. HttpStatusCode: {httpStatusCode}.")
        { 
        }

        public InvalidFunctionResponseException(string functionName,
            HttpStatusCode? httpStatusCode,
            string errorMessage)
            : base($"Fpl API returned invalid response. Function: {functionName}. HttpStatusCode: {httpStatusCode}. InnerException: {errorMessage}.")
        {
        }
    }
}
