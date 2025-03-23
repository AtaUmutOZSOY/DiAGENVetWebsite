using Microsoft.Extensions.DependencyInjection;

namespace DiagenVet.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
} 