using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Interfaces
{
    public interface IFormFactory<T>
    {
        T Create(params object[] args);
    }

    public class FormFactory<T> : IFormFactory<T> where T : class
    {
        private readonly IServiceProvider _provider;

        public FormFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Create(params object[] args)
        {
            return ActivatorUtilities.CreateInstance<T>(_provider, args);
        }
    }
}
