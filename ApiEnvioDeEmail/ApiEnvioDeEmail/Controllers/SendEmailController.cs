using Core.DTOs;
using Core.UseCases.SendInvoice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiEnvioDeEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendInvoiceUseCase _sendInvoice;

        public SendEmailController(ISendInvoiceUseCase sendInvoice)
        {
            _sendInvoice = sendInvoice;
        }

        [HttpPost]
        public ActionResult Post([FromBody]InvoiceDto invoiceDto)
        {
            try
            {
                _sendInvoice.Execute(invoiceDto);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
