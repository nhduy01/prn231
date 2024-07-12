using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;
using Application.IService.ICommonService;
using Application.SendModels.Topic;
using Application.Services.CommonService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infracstructures;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebAPI.Validation.TopicValidation;

namespace WebAPI;

public static class DependencyInjection
{
    public static void AddWebAPIService(this IServiceCollection services, WebApplicationBuilder builder,  IConfiguration config)
    {

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("NetVeXanh")));
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        services.AddControllers().AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
       
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();
        services.AddHttpContextAccessor();
        services.AddMemoryCache();
        //services.AddScoped<IClaimsServices, ClaimsServices>();
        //Adding Session
        services.AddDistributedMemoryCache(); //Adding cache in memory for session.
        services.AddSession(); //Adding session.
        services.AddTransient<ISessionServices, SessionServices>();

        var secretKeyBytes = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                //auto generate token
                ValidateIssuer = false,
                ValidateAudience = false,

                //sign in token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddFluentValidationClientsideAdapters();

        services.AddCors(options =>
        {
            options.AddPolicy("_myAllowSpecificOrigins",
                policy =>
                {
                    policy.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
                });
        });


        services.AddSwaggerGen(sw =>
        {
            sw.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "1.0" });
            sw.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insert JWT Token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            sw.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        
    }
    public static IServiceCollection AddModelValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<TopicRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<TopicUpdateRequestValidator>();


        return services;
    }
}