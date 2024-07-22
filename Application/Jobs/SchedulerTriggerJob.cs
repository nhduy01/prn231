using Quartz;
using Microsoft.Extensions.DependencyInjection;
using Application.IService.ICommonService;

namespace Application.Jobs;

public class SchedulerTriggerJob : IJob
{
    private readonly IServiceProvider _serviceProvider;

    public SchedulerTriggerJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        using var scope = _serviceProvider.CreateScope();
        var schedulerTrigger = scope.ServiceProvider.GetRequiredService<ISchedulerTrigger>();
        await schedulerTrigger.ScheduleTrigger();
    }
}