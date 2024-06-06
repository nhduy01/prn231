using Application;
using Application.IValidators;
using Infracstructures.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infracstructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {
            

            

            // Use local DB
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("NetVeXanh")));

            // Use Azure DB
            // services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("FATMS.AzureDB")));

            // Use Azure storage 
            /*services.AddScoped(_ =>
            {
                return new BlobServiceClient(config.GetConnectionString("AzureBlobStorage"));
            });
            services.AddAutoMapper(typeof(MapperConfigs).Assembly);*/


            return services;
        }
    }
}
