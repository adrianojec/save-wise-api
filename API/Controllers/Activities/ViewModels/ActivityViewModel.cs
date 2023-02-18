using Application.Commands.Activities.Dtos;

namespace API.Controllers.Activities.ViewModels
{
    public class ActivityViewModel
    {
        public ActivityViewModel(ActivityDto item)
        {
            TransactionId = item.TransactionId;
            DateCreated = item.DateCreated;
        }
        public Guid TransactionId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}