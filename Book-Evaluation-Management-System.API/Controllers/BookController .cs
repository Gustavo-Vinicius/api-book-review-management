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

        [HttpGet("get-all-books")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var query = new GetBooksQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpGet("get-book-by-id")]
        public async Task<IActionResult> GetBookByIdAsync([FromQuery] GetBookByIdQuery query)
        {
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        [HttpPost("register-new-book")]
        public async Task<IActionResult> RegisterNewBookAsync([FromBody] RegisterNewBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("upload-book-cover")]
        public async Task<IActionResult> UploadCoverImage(UploadCoverImageBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("edit-book")]
        public async Task<IActionResult> EditBookAsync([FromBody] EditBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete-book")]
        public async Task<IActionResult> DeleteBookAsync([FromQuery] DeleteBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}