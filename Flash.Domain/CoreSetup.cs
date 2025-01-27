using Flash.Domain.Interfaces.ICardRepository;
using Flash.Domain.Repositories.CardRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Flash.Core.Domain
{
    public static class CoreSetup
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
        }
    }
}
