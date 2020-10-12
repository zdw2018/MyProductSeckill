using PaymentMicroService.Models;
using PaymentMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PaymentMicroService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRespository _paymentRespository;
        public PaymentService(IPaymentRespository paymentRespository)
        {
            this._paymentRespository = paymentRespository;
        }
        public void Create(Payment payment)
        {
            _paymentRespository.Create(payment);
        }

        public void Delete(Payment payment)
        {
            _paymentRespository.Delete(payment);
        }

        public Payment GetPaymentById(int Id)
        {
          return  _paymentRespository.GetPaymentById(Id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _paymentRespository.GetPayments();
        }

        public bool PaymentExists(int Id)
        {
            return _paymentRespository.PaymentExists(Id);
        }

        public void Update(Payment payment)
        {
            _paymentRespository.Update(payment);
        }
    }
}
