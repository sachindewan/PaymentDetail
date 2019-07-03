using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Data
{
    public class PaymentDetailsContext:DbContext
    {
        public PaymentDetailsContext(DbContextOptions<PaymentDetailsContext> dbContextOptions):base(dbContextOptions)
        {
                
        }
       public DbSet<PaymentDetails> paymentDetails { get; set; }
    }
}
