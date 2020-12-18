using Core.DTOs;
using System;
using System.Net;
using System.Net.Mail;

namespace Core.UseCases.SendInvoice
{
    public class SendInvoiceUseCase : ISendInvoiceUseCase
    {
        public void Execute(InvoiceDto invoiceDto)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = "Pagamento realizado com sucesso!";
            mail.From = new MailAddress("norenply@norenply.com");
            mail.To.Add(invoiceDto.Email);
            mail.Body = "Seu pagamento código " + invoiceDto.Payment.PaymentId + " foi realizado com sucesso!";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            NetworkCredential netCre = new NetworkCredential("EMAIL", "SENHA");
            smtp.Credentials = netCre;

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
