using Book_Evaluation_Management_System.Application.Queries.ReviewBook.GetBooksReadInYear;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Evaluation_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("books-read-in-year/{year}")]
        public async Task<IActionResult> GetBooksReadInYear(int year)
        {
            var result = await _mediator.Send(new GetBooksReadInYearQuery(year));
            return Ok(result);
        }
    }
}