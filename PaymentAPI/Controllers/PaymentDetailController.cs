using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Models;
using PaymentAPI.Models.ApiResponse;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailsContext _paymentDetailsContext;

        public PaymentDetailController(PaymentDetailsContext paymentDetailsContext)
        {
            _paymentDetailsContext = paymentDetailsContext;
        }

        [HttpGet]
        public async Task<PaymentResponse> GetPaymentDetailsAsync()
        {
            var _paymentDetails = await _paymentDetailsContext.paymentDetails.ToListAsync();
            if(_paymentDetails!=null)
            return  new OKRespone(_paymentDetails);

            return new _404Response(StatusCodes.Status404NotFound, "payment details not found");
        }

        [HttpPut("{id}")]
        public async Task<PaymentResponse> PutPaymentDetailsAsync(int id , [FromBody]PaymentDetails paymentDetails)
        {
            var _paymentDetails = await _paymentDetailsContext.paymentDetails.Where(ptm=>ptm.PaymentDetailsId==id).FirstOrDefaultAsync();
            if (_paymentDetails == null)
            {
                return new _404Response(StatusCodes.Status404NotFound, "payment details not found");
            }
            _paymentDetails.CardNumber = paymentDetails.CardNumber;
            _paymentDetails.CardOwnerName = paymentDetails.CardOwnerName;
            _paymentDetails.CVV = paymentDetails.CVV;
            _paymentDetails.ExpirationDate = paymentDetails.ExpirationDate;
            await _paymentDetailsContext.SaveChangesAsync();
            return new OKRespone(_paymentDetails,message: "Record modified successfully");
        }

        [HttpPost()]
        public async Task<PaymentResponse> PostPaymentDetailsAsync([FromBody]PaymentDetails paymentDetails)
        {
            var paymentDetailsExist = _paymentDetailsContext.paymentDetails.Where(cardno => cardno.CardNumber == paymentDetails.CardNumber).FirstOrDefault();
            if (paymentDetailsExist != null)
            {
                return new _303SeeOther(StatusCodes.Status303SeeOther, "Record already found please check and try again");
            }
           await _paymentDetailsContext.paymentDetails.AddAsync(paymentDetails);
            _paymentDetailsContext.SaveChanges();          
            return new _201Response(StatusCodes.Status201Created,"record created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<PaymentResponse> DeletePaymentDetailsAsync(int id)
        {
            var _paymentDetails = await _paymentDetailsContext.paymentDetails.Where(ptm => ptm.PaymentDetailsId == id).FirstOrDefaultAsync();
            if (_paymentDetails == null)
            {
                return new _404Response(StatusCodes.Status404NotFound, "record not found");
            }
            _paymentDetailsContext.Remove(_paymentDetails);
            await _paymentDetailsContext.SaveChangesAsync();
            return new OKRespone(_paymentDetails,"Record deleted successfully");
        }
    }
}