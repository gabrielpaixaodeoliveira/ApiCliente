using ApiCliente.Aplication;
using ApiCliente.Aplication.Interface;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Domain.Interfaces.Services;
using ApiCliente.Domain.Services;
using ApiCliente.Infra.Data.Context;
using ApiCliente.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCliente.Infra.CrossCutting
{
    public class IOC
    {

        public void InjecaoAppService(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IClienteAppService, ClienteAppService>();
        }
        public void InjecaoDomain(IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IClienteService, ClienteService>();
        }
        public void InjecaoRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
        //    services.AddScoped<DbContext, ClienteContext>();
        }
    }
}
