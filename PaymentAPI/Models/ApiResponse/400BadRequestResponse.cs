using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.ApiResponse
{
    public class _400BadRequestResponse : PaymentResponse
    {
        public IEnumerable<string> Errors { get; }
        public _400BadRequestResponse(ModelStateDictionary modelState=null,string message=null) : base(400)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }
            Errors = modelState.SelectMany(x => x.Value.Errors).Select(x=>x.ErrorMessage).ToList();
        }
    }
}
