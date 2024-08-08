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

        /// <summary>
        /// Retrieves a report of books read in a specific year.
        /// </summary>
        /// <param name="year">The year to filter the books read.</param>
        /// <returns>A list of books read in the specified year.</returns>
        [HttpGet("books-read-in-year/{year}")]
        public async Task<IActionResult> GetBooksReadInYear(int year)
        {
            var result = await _mediator.Send(new GetBooksReadInYearQuery(year));
            return Ok(result);
        }
    }
}