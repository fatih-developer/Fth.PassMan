using Microsoft.Extensions.DependencyInjection;

namespace MainCore.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}