using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using DiagenVet.Core.CrossCuttingConcerns.Caching;
using DiagenVet.Core.Utilities.Interceptors;
using DiagenVet.Core.Utilities.IoC;

namespace DiagenVet.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
} 