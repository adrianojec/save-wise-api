using Application.Commands.Activities.Dtos;
using Application.Core;

namespace Application.Commands.Activities
{
    public interface IGetActivitiesCommand
    {
        Task<Result<List<ActivityDto>>> ExecuteCommand(Guid accountId);
    }
}