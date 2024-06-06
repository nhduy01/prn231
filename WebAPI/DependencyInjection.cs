using Application;
using Application.IValidators;
using FluentValidation.AspNetCore;
using Infracstructures;
using Infracstructures.Validators;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WebAPI.Interfaces;
using WebAPI.IRepositories;
using WebAPI.IService;
using WebAPI.IService.ICommonService;
using WebAPI.Repositories;
using WebAPI.Services;
using WebAPI.Services.CommonService;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static void AddWebAPIService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

           

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region Config Repository and Service
            // Account
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountService, AccountService>();

            // Award
            services.AddTransient<IAwardRepository, AwardRepository>();
            services.AddTransient<IAwardService, AwardService>();

            // AwardSchedule
            services.AddTransient<IAwardScheduleRepository, AwardScheduleRepository>();
            services.AddTransient<IAwardScheduleService, AwardScheduleService>();

            // Collection
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<ICollectionService, CollectionService>();

            // EducationalLevel
            services.AddTransient<IEducationalLevelRepository, EducationalLevelRepository>();
            services.AddTransient<IEducationalLevelService, EducationalLevelService>();

            // Competitor
            services.AddTransient<ICompetitorRepository, CompetitorRepository>();
            services.AddTransient<ICompetitorService, CompetitorService>();

            // Image
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IImageService, ImageService>();

            // Notification
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<INotificationService, NotificationService>();

            // Painting
            services.AddTransient<IPaintingRepository, PaintingRepository>();
            services.AddTransient<IPaintingService, PaintingService>();

            // PaintingCollection
            services.AddTransient<IPaintingCollectionRepository, PaintingCollectionRepository>();
            services.AddTransient<IPaintingCollectionService, PaintingCollectionService>();

            // Post
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService, PostService>();

            // PostImage
            services.AddTransient<IPostImageRepository, PostImageRepository>();
            services.AddTransient<IPostImageService, PostImageService>();

            // Resources
            services.AddTransient<IResourcesRepository, ResourcesRepository>();
            services.AddTransient<IResourcesService, ResourcesService>();

            // Round
            services.AddTransient<IRoundRepository, RoundRepository>();
            services.AddTransient<IRoundService, RoundService>();

            // Schedule
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IScheduleService, ScheduleService>();

            // Sponsor
            services.AddTransient<ISponsorRepository, SponsorRepository>();
            services.AddTransient<ISponsorService, SponsorService>();

            // Topic
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ITopicService, TopicService>();

            // Contest
            services.AddTransient<IContestRepository, ContestRepository>();
            services.AddTransient<IContestService, ContestService>();


            #endregion

            #region Config validators
            //User Validator
            services.AddTransient<IAccountValidator, AccountValidator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion


            services.AddSingleton<ICurrentTime, CurrentTime>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddHttpContextAccessor();
            //services.AddScoped<IClaimsServices, ClaimsServices>();
            //Adding Session
            services.AddDistributedMemoryCache(); //Adding cache in memory for session.
            services.AddSession(); //Adding session.
            services.AddTransient<ISessionServices, SessionServices>();
            services.AddAuthorization();
            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });*/
            services.AddFluentValidationClientsideAdapters();


            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });
        }
    }
}
