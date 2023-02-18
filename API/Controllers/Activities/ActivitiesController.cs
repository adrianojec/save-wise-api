using API.Controllers.Activities.ViewModels;
using Application.Commands.Activities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Activities
{
    [ApiController]
    [Route("api/accounts/{accountId}/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IGetActivitiesCommand _getActivitiesCommand;
        public ActivitiesController(IGetActivitiesCommand getActivitiesCommand)
        {
            _getActivitiesCommand = getActivitiesCommand;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityViewModel>>> GetAll([FromRoute] Guid accountId)
        {
            var activities = await _getActivitiesCommand.ExecuteCommand(accountId);
            return activities.Select(activity => new ActivityViewModel(activity)).ToList();
        }
    }
}