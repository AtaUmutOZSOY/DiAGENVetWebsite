using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DiagenVet.Core.CrossCuttingConcerns.Caching;
using DiagenVet.Core.CrossCuttingConcerns.Caching.Microsoft;
using DiagenVet.Core.Utilities.IoC;

namespace DiagenVet.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
} 