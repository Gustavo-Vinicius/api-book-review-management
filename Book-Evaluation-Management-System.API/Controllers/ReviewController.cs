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

        [HttpGet("review-by-book/{idBook}")]
        public async Task<IActionResult> GetByLivroId(int idBook)
        {
            var query = new GetReviewsByBookQuery(idBook);
            var assessments = await _mediator.Send(query);
            return Ok(assessments);
        }

        [HttpGet("review-by-user/{idUser}")]
        public async Task<IActionResult> GetByUsuarioId(int idUser)
        {
            var query = new GetReviewsByUserQuery(idUser);
            var assessments = await _mediator.Send(query);
            return Ok(assessments);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllReviewQuery();
            var review = await _mediator.Send(query);
            return Ok(review);
        }

        [HttpPost("add-review-book")]
        public async Task<IActionResult> Create([FromBody] AddReviewBookCommand command)
        {
            var avaliacaoId = await _mediator.Send(command);
            return Ok(avaliacaoId);
        }
    }
}