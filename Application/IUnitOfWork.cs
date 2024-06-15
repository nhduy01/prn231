using Application.IRepositories;

namespace Infracstructures;

public interface IUnitOfWork
{
    public IAccountRepository AccountRepo { get; }
    public IAwardRepository AwardRepo { get; }
    public IAwardScheduleRepository AwardScheduleRepo { get; }
    public ICollectionRepository CollectionRepo { get; }
    public IEducationalLevelRepository EducationalLevelRepo { get; }
    public ICompetitorRepository CompetitorRepo { get; }
    public IImageRepository ImageRepo { get; }
    public INotificationRepository NotificationRepo { get; }
    public IPaintingRepository PaintingRepo { get; }
    public IPaintingCollectionRepository PaintingCollectionRepo { get; }
    public IPostRepository PostRepo { get; }
    public IResourcesRepository ResourcesRepo { get; }
    public IRoundRepository RoundRepo { get; }
    public IScheduleRepository ScheduleRepo { get; }
    public ISponsorRepository SponsorRepo { get; }
    public ITopicRepository TopicRepo { get; }
    public IContestRepository ContestRepo { get; }

    public Task<int> SaveChangesAsync();
}