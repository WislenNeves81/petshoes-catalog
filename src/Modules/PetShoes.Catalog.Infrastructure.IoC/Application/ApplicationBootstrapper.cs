using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Catalog.Application.AppShoe;
using PetShoes.Catalog.Application.AppShoe.Interface;

namespace PetShoes.Catalog.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service)
        {
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<IShoeAppService, ShoeAppService>();
        }
    }
}
