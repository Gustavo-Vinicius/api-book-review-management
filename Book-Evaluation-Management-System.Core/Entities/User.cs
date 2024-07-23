namespace Book_Evaluation_Management_System.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}