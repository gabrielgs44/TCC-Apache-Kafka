using Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace Core.UseCases.MakePayments
{
    public interface IMakePaymentUseCase
    {
        public Task<Guid> ExecuteAsync(MakePagamentDto makePagamentDto);
    }
}
