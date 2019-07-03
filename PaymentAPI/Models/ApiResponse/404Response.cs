using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.ApiResponse
{
    public class _404Response : PaymentResponse
    {
        public _404Response(int statusCode, string message = null) : base(statusCode, message)
        {
        }
    }
}
