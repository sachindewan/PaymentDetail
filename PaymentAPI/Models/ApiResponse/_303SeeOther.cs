using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.ApiResponse
{
    public class _303SeeOther : PaymentResponse
    {
        public _303SeeOther(int statusCode, string message = null) : base(statusCode, message)
        {
        }
    }
}
