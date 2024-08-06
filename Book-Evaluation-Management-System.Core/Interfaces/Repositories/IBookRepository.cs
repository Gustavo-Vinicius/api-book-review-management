using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Models.InputModels;

namespace Book_Evaluation_Management_System.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task AddBookAsync(string title, string description, string iSBN, string author, string publishingCompany, string gender, int yearOfPublication, int quantityPages, DateTime creationDate, decimal averageGrade, byte[] bookCover);
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDTO>> GetBooks();
        Task EditBookAsync(int id, BookDTO bookDTO);
        Task DeleteBookAsync(int id);
        Task UploadCoverImageBookAsync(int id, UploadBookCoverInputModel coverImageInputModel);
    }

}