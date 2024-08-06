namespace Book_Evaluation_Management_System.Core.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Note { get; set; }
        public string Description { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
    }
}