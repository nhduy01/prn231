using Application;
using Application.Interfaces;
using Application.IValidators;
using Application.Repositories;
using Application.Services;
using Infracstructures.Mappers;
using Infracstructures.Repositories;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Config Repository and Service
            //User
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            #endregion

            #region Config validators
            //User Validator
            services.AddTransient<IAccountValidator, AccountValidator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion


            services.AddSingleton<ICurrentTime, CurrentTime>();

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
