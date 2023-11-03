namespace ChillApplication.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public bool Resolved { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ResolveDate { get; set; }
        public Operator Operator { get; set; }

    }
}
