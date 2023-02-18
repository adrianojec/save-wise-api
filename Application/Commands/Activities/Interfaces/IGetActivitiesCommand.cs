using Application.Commands.Activities.Dtos;

namespace Application.Commands.Activities
{
    public interface IGetActivitiesCommand
    {
        Task<List<ActivityDto>> ExecuteCommand(Guid accountId);
    }
}