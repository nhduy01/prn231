using Infracstructures;
using WebAPI.IRepositories;
using WebAPI.Repositories;

namespace WebAPI
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IAwardRepository _awardRepository;
        private readonly IAwardScheduleRepository _awardScheduleRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IEducationalLevelRepository _educationalLevelRepository;
        private readonly ICompetitorRepository _competitorRepository;
        private readonly IImageRepository _imageRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IPaintingRepository _paintingRepository;
        private readonly IPaintingCollectionRepository _paintingCollectionRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IResourcesRepository _resourcesRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IContestRepository _contestRepository;


        public UnitOfWork(AppDbContext context, IAccountRepository accountRepository,
                                                    IAwardRepository awardRepository,
                                                    IAwardScheduleRepository awardScheduleRepository,
                                                    ICollectionRepository collectionRepository,
                                                    IEducationalLevelRepository educationalLevelRepository,
                                                    ICompetitorRepository competitorRepository,
                                                    IImageRepository imageRepository,
                                                    INotificationRepository notificationRepository,
                                                    IPaintingRepository paintingRepository,
                                                    IPaintingCollectionRepository paintingCollectionRepository,
                                                    IPostRepository postRepository,
                                                    IPostImageRepository postImageRepository,
                                                    IResourcesRepository resourcesRepository,
                                                    IRoundRepository roundRepository,
                                                    IScheduleRepository scheduleRepository,
                                                    ISponsorRepository sponsorRepository,
                                                    ITopicRepository topicRepository,
                                                    IContestRepository contestRepository)
            
        {
            _context = context;
            _accountRepository = accountRepository;
            _awardRepository = awardRepository;
            _awardScheduleRepository = awardScheduleRepository;
            _collectionRepository = collectionRepository;
            _educationalLevelRepository = educationalLevelRepository;
            _competitorRepository = competitorRepository;
            _imageRepository = imageRepository;
            _notificationRepository = notificationRepository;
            _paintingRepository = paintingRepository;
            _paintingCollectionRepository = paintingCollectionRepository;
            _postRepository = postRepository;
            _postImageRepository = postImageRepository;
            _resourcesRepository = resourcesRepository;
            _roundRepository = roundRepository;
            _scheduleRepository = scheduleRepository;
            _sponsorRepository = sponsorRepository;
            _topicRepository = topicRepository;
            _contestRepository = contestRepository;

        }

        public IAccountRepository AccountRepo => _accountRepository;
        public IAwardRepository AwardRepo => _awardRepository;
        public IAwardScheduleRepository AwardScheduleRepo => _awardScheduleRepository;
        public ICollectionRepository CollectionRepo => _collectionRepository;
        public IEducationalLevelRepository EducationalLevelRepo => _educationalLevelRepository;
        public ICompetitorRepository CompetitorRepo => _competitorRepository;
        public IImageRepository ImageRepo => _imageRepository;
        public INotificationRepository NotificationRepo => _notificationRepository;
        public IPaintingRepository PaintingRepo => _paintingRepository;
        public IPaintingCollectionRepository PaintingCollectionRepo => _paintingCollectionRepository;
        public IPostRepository PostRepo => _postRepository;
        public IPostImageRepository PostImageRepo => _postImageRepository;
        public IResourcesRepository ResourcesRepo => _resourcesRepository;
        public IRoundRepository RoundRepo => _roundRepository;
        public IScheduleRepository ScheduleRepo => _scheduleRepository;
        public ISponsorRepository SponsorRepo => _sponsorRepository;
        public ITopicRepository TopicRepo => _topicRepository;
        public IContestRepository ContestRepo => _contestRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}