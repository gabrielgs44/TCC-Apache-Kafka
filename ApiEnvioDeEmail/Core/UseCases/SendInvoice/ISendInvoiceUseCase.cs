using Core.DTOs;

namespace Core.UseCases.SendInvoice
{
    public interface ISendInvoiceUseCase
    {
        public void Execute(InvoiceDto invoiceDto);
    }
}
