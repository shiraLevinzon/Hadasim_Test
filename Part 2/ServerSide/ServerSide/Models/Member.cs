namespace ServerSide.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime Birthday { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile { get; set; }
        public DateTime PositiveAnswerDate { get; set; }
        public DateTime RecoveryDate { get; set; }

    }
}
