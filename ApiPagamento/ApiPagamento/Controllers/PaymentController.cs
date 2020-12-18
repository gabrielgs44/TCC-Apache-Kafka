using Core.UseCases.MakePayments;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class PaymentController : ControllerBase
    {
        private readonly IMakePaymentUseCase _makePayment;

        public PaymentController(IMakePaymentUseCase makePayment)
        {
            _makePayment = makePayment;
        }

        [HttpPost]
        [Route("payment")]
        public async Task<ActionResult<Guid>> RealizarPagamentoAsync([FromBody] MakePagamentDto makePayment)
        {
            try
            {
                return Ok(await _makePayment.ExecuteAsync(makePayment));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

