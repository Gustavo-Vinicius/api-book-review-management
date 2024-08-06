using Book_Evaluation_Management_System.Core.DTOs;
using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Enums;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Book_Evaluation_Management_System.Core.Models.InputModels;

namespace Book_Evaluation_Management_System.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IUnityOfWork _unityOfWork;
        public BookRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public async Task AddBookAsync(string title, string description, string iSBN, string author, string publishingCompany, string gender, int yearOfPublication, int quantityPages, DateTime creationDate, decimal averageGrade, byte[] bookCover)
        {
            if (!Enum.TryParse<GeneroLivroEnum>(gender, true, out var genero))
            {
                throw new ArgumentException($"Invalid value for gender: {gender}");
            }

            var book = new Book
            {
                Title = title,
                Description = description,
                ISBN = iSBN,
                Author = author,
                PublishingCompany = publishingCompany,
                Gender = genero,
                YearOfPublication = yearOfPublication,
                QuantityPages = quantityPages,
                CreationDate = creationDate,
                AverageGrade = averageGrade,
                BookCover = bookCover
            };

            await _unityOfWork.Books.AddAsync(book);

            await _unityOfWork.CompleteAsync();
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _unityOfWork.Books.GetByIdAsync(id);

            if (book == null)
            {
                throw new Exception("No books in the database.");
            }

            var bookDTO = new BookDTO
            {
                Title = book.Title,
                Description = book.Description,
                ISBN = book.ISBN,
                Author = book.Author,
                PublishingCompany = book.PublishingCompany,
                Gender = book.Gender,
                YearOfPublication = book.YearOfPublication,
                QuantityPages = book.QuantityPages,
                CreationDate = book.CreationDate,
                AverageGrade = book.AverageGrade
            };

            return bookDTO;

        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            IEnumerable<Book> books = await _unityOfWork.Books.GetAllAsync();

            IEnumerable<BookDTO> bookDTOs = books.Select(books => new BookDTO
            {
                Title = books.Title,
                Description = books.Description,
                ISBN = books.ISBN,
                Author = books.Author,
                PublishingCompany = books.PublishingCompany,
                Gender = books.Gender,
                YearOfPublication = books.YearOfPublication,
                QuantityPages = books.QuantityPages,
                CreationDate = books.CreationDate,
                AverageGrade = books.AverageGrade
            });

            return bookDTOs;

        }

        public async Task EditBookAsync(int id, BookDTO bookDTO)
        {
            var bookExisting = await _unityOfWork.Books.GetByIdAsync(id);
            if (bookExisting == null)
            {
                throw new Exception("Book not found !");
            }

            bookExisting.Title = bookDTO.Title;
            bookExisting.Description = bookDTO.Description;
            bookExisting.ISBN = bookDTO.ISBN;
            bookExisting.Author = bookDTO.Author;
            bookExisting.PublishingCompany = bookDTO.PublishingCompany;
            bookExisting.Gender = bookDTO.Gender;
            bookExisting.YearOfPublication = bookDTO.YearOfPublication;
            bookExisting.QuantityPages = bookDTO.QuantityPages;
            bookExisting.CreationDate = bookDTO.CreationDate;
            bookExisting.AverageGrade = bookDTO.AverageGrade;
            bookExisting.BookCover = bookDTO.BookCover;


            _unityOfWork.Books.Update(bookExisting);

            await _unityOfWork.CompleteAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _unityOfWork.Books.GetByIdAsync(id);
            _unityOfWork.Books.Delete(book);
            await _unityOfWork.CompleteAsync();
        }

        private static string ConvertImageToBase64String(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
            {
                throw new ArgumentException("Invalid image path or file does not exist.");
            }

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        public async Task UploadCoverImageBookAsync(int id, UploadBookCoverInputModel coverImageInputModel)
        {
            var book = await _unityOfWork.Books.GetByIdAsync(id);

            using (var memoryStream = new MemoryStream())
            {
                await coverImageInputModel.CoverImage.CopyToAsync(memoryStream);
                book.BookCover = memoryStream.ToArray();
            }

            _unityOfWork.Books.Update(book);

            await _unityOfWork.CompleteAsync();

        }
    }
}