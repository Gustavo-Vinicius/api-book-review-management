using Book_Evaluation_Management_System.Application.Commands.User.DeleteUser;
using Book_Evaluation_Management_System.Application.Commands.User.EditUser;
using Book_Evaluation_Management_System.Application.Commands.User.RegisterNewUser;
using Book_Evaluation_Management_System.Application.Queries.Book.GetBookById;
using Book_Evaluation_Management_System.Application.Queries.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Evaluation_Management_System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var query = new GetUserQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] GetBookByIdQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost("register-new-user")]
        public async Task<IActionResult> RegisterNewBookAsync([FromBody] RegisterNewUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("edit-user")]
        public async Task<IActionResult> EditBookAsync([FromBody] EditUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteBookAsync([FromQuery] DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}