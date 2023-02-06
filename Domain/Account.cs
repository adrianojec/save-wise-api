namespace Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}