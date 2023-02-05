using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Amount
    {
        public Guid Id { get; set; }
        [ForeignKey("Save")]
        public Guid SaveId { get; set; }
        public Save Save { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public double Total { get; set; } = 0.0;
        public DateTime DateCreate { get; set; }

    }
}