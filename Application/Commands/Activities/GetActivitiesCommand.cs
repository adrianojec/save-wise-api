using Application.Commands.Activities.Dtos;
using Application.Repositories.ActivityRepository;

namespace Application.Commands.Activities
{
    public class GetActivitiesCommand : IGetActivitiesCommand
    {
        private readonly IActivityRepository _activityRepository;
        public GetActivitiesCommand(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public async Task<List<ActivityDto>> ExecuteCommand(Guid accountId)
        {
            var activities = await _activityRepository.GetAll();

            if (activities == null) throw new NullReferenceException();

            var accountActivities = activities.Where(activity => activity.AccountId == accountId).ToList();
            return accountActivities.Select(activity => new ActivityDto(activity)).ToList();
        }
    }
}