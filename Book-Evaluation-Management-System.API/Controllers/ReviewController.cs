using Book_Evaluation_Management_System.Application.Commands.ReviewBook.AddReviewBook;
using Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetAllReview;
using Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByBook;
using Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetReviewsByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Evaluation_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all reviews for a specific book by book ID.
        /// </summary>
        /// <param name="idBook">The ID of the book.</param>
        /// <returns>A list of reviews for the specified book.</returns>
        [HttpGet("review-by-book/{idBook}")]
        public async Task<IActionResult> GetByLivroId(int idBook)
        {
            var query = new GetReviewsByBookQuery(idBook);
            var assessments = await _mediator.Send(query);
            return Ok(assessments);
        }

        /// <summary>
        /// Retrieves all reviews made by a specific user by user ID.
        /// </summary>
        /// <param name="idUser">The ID of the user.</param>
        /// <returns>A list of reviews made by the specified user.</returns>
        [HttpGet("review-by-user/{idUser}")]
        public async Task<IActionResult> GetByUsuarioId(int idUser)
        {
            var query = new GetReviewsByUserQuery(idUser);
            var assessments = await _mediator.Send(query);
            return Ok(assessments);
        }

        /// <summary>
        /// Retrieves all reviews.
        /// </summary>
        /// <returns>A list of all reviews.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllReviewQuery();
            var review = await _mediator.Send(query);
            return Ok(review);
        }

        /// <summary>
        /// Adds a new review for a book.
        /// </summary>
        /// <param name="command">Command containing the review data.</param>
        /// <returns>The ID of the newly created review.</returns>
        [HttpPost("add-review-book")]
        public async Task<IActionResult> Create([FromBody] AddReviewBookCommand command)
        {
            var avaliacaoId = await _mediator.Send(command);
            return Ok(avaliacaoId);
        }
    }
}