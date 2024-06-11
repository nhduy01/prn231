using Application;
using Application.Authentication;
using Application.Interfaces;
using Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.IService.ICommonService;
using Application.IRepositories;
using Infracstructures.Repositories;
using Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Application.Services.CommonService;
using AuthenticationService = Microsoft.AspNetCore.Authentication.AuthenticationService;

namespace Infracstructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Config Repository and Service
            //Authen
            services.AddTransient<IAuthentication, Authentication>();
            services.AddTransient<IAuthenticationService, Application.Services.AuthenticationService>();
            
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
            //services.AddTransient<IAccountValidator, AccountValidator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion
            services.AddSingleton<IClaimsService, ClaimsService>();
            services.AddSingleton<ICurrentTime, CurrentTime>();

            // Use local DB
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("NetVeXanh")));


            services.AddAutoMapper(typeof(MapperConfigs).Assembly);


            return services;
        }
    }
}
