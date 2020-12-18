using Core.UseCases.MakePayments;
using ExternalService.SendInvoice;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Ioc
{
    public static class DependenceInjection
    {
        public static void AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<IMakePaymentUseCase, MakePaymentUseCase>();
            services.AddScoped<ISendInvoiceExternalService, SendInvoiceExternalService>();
        }
    }
}