using PaymentMicroService.Context;
using PaymentMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroService.Repositories
{
    public class PaymentRespository : IPaymentRespository
    {
        private readonly PaymentContext _paymentContext;
        public PaymentRespository(PaymentContext paymentContext)
        {
            this._paymentContext = paymentContext;
        }
        public void Create(Payment payment)
        {
            _paymentContext.Set<Payment>().Add(payment);
            _paymentContext.SaveChanges();
        }

        public void Delete(Payment payment)
        {
            _paymentContext.Set<Payment>().Remove(payment);
            _paymentContext.SaveChanges();
        }

        public Payment GetPaymentById(int Id)
        {
          return  _paymentContext.Set<Payment>().Find(Id);
        
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _paymentContext.Set<Payment>().ToList();
        }

        public bool PaymentExists(int Id)
        {
            return _paymentContext.Set<Payment>().Any(x=>x.Id==Id);
        }

        public void Update(Payment payment)
        {
            _paymentContext.Set<Payment>().Update(payment);
            _paymentContext.SaveChanges();
        }
    }
}
