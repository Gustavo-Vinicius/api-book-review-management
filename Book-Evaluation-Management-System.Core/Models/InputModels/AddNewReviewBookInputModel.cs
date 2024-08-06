namespace Book_Evaluation_Management_System.Core.Models.InputModels
{
    public class AddNewReviewBookInputModel
    {
        public int Note { get; set; }
        public string Description { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        
    }
}