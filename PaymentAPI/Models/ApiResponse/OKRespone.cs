using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.ApiResponse
{
    public class OKRespone : PaymentResponse
    {
        public object Result { get;}
        public OKRespone(object result,string message=null) : base(200,message)
        {
            Result = result;
        }
    }
}
