using Book_Evaluation_Management_System.Application.Commands.Book.DeleteBook;
using Book_Evaluation_Management_System.Application.Commands.Book.EditBook;
using Book_Evaluation_Management_System.Application.Commands.Book.RegisterNewBook;
using Book_Evaluation_Management_System.Application.Commands.Book.UploadCoverImageBook;
using Book_Evaluation_Management_System.Application.Queries.Book.GetBookById;
using Book_Evaluation_Management_System.Application.Queries.Book.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Evaluation_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
         /// <summary>
        /// Retrieves the list of all books.
        /// </summary>
        /// <returns>A list of books.</returns>
        [HttpGet("get-all-books")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var query = new GetBooksQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="query">Query containing the book ID.</param>
        /// <returns>The book corresponding to the provided ID.</returns>
        [HttpGet("get-book-by-id")]
        public async Task<IActionResult> GetBookByIdAsync([FromQuery] GetBookByIdQuery query)
        {
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        /// <summary>
        /// Registers a new book.
        /// </summary>
        /// <param name="command">Command containing the new book data.</param>
        /// <returns>A success status with no content.</returns>
        [HttpPost("register-new-book")]
        public async Task<IActionResult> RegisterNewBookAsync([FromBody] RegisterNewBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Uploads a book cover image.
        /// </summary>
        /// <param name="command">Command containing the book cover image.</param>
        /// <returns>A success status with no content.</returns>
        [HttpPost("upload-book-cover")]
        public async Task<IActionResult> UploadCoverImage(UploadCoverImageBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Edits the information of an existing book.
        /// </summary>
        /// <param name="command">Command containing the updated book data.</param>
        /// <returns>A success status with no content.</returns>
        [HttpPut("edit-book")]
        public async Task<IActionResult> EditBookAsync([FromBody] EditBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="command">Command containing the ID of the book to be deleted.</param>
        /// <returns>A success status with no content.</returns>
        [HttpDelete("delete-book")]
        public async Task<IActionResult> DeleteBookAsync([FromQuery] DeleteBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}