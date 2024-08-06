using Microsoft.AspNetCore.Http;

namespace Book_Evaluation_Management_System.Core.Models.InputModels
{
    public class UploadBookCoverInputModel 
    {
        public IFormFile CoverImage { get; set; }
    }
}