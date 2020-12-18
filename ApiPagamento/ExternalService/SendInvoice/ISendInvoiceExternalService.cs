using Domain.Entities;
using System.Threading.Tasks;

namespace ExternalService.SendInvoice
{
    public interface ISendInvoiceExternalService
    {
        public Task ExecuteAsync(InvoiceDto invoice);
    }
}
