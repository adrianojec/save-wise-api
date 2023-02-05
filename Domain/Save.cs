using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Save
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid AmountId { get; set; }
        public Amount Amount { get; set; } = default!;
    }
}