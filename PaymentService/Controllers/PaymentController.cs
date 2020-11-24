using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentMicroService.Models;
using PaymentMicroService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentMicroService.Controllers
{
    [Route("Payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this._paymentService = paymentService;
        }
        // GET: api/<PaymentController>
        [HttpGet]
        public ActionResult<IEnumerable<Payment>> GetPayment()
        {
            return _paymentService.GetPayments().ToList();
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public ActionResult<Payment> GetPayment(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            return payment;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public ActionResult<Payment> PostPayment(Payment payment)
        {
            _paymentService.Create(payment);
            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public IActionResult PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }
            try
            {
                _paymentService.Update(payment);

            }
            catch (DbUpdateConcurrencyException)
            {

                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public ActionResult<Payment> DeletePayment(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
            {
                return NotFound();
            }
            _paymentService.Delete(payment);
            return payment;
        }
        private bool PaymentExists(int id)
        {
            return _paymentService.PaymentExists(id);
        }

    }
}
