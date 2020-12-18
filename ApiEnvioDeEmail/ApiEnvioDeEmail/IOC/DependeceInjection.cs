using Core.UseCases.SendInvoice;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Ioc
{
    public static class DependenceInjection
    {
        public static void AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<ISendInvoiceUseCase, SendInvoiceUseCase>();
        }
    }
}