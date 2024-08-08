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

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var query = new GetUserQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="Id">Query containing the user ID.</param>
        /// <returns>The user corresponding to the provided ID.</returns>
        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int Id)
        {
            var userQuery = new GetBookByIdQuery(Id);    
            var user = await _mediator.Send(userQuery);
            return Ok(user);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="command">Command containing the new user data.</param>
        /// <returns>A success status with no content.</returns>
        [HttpPost("register-new-user")]
        public async Task<IActionResult> RegisterNewBookAsync([FromBody] RegisterNewUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Edits an existing user.
        /// </summary>
        /// <param name="command">Command containing the updated user data.</param>
        /// <returns>A success status with no content.</returns>
        [HttpPut("edit-user")]
        public async Task<IActionResult> EditBookAsync([FromBody] EditUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

         /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="command">Command containing the ID of the user to be deleted.</param>
        /// <returns>A success status with no content.</returns>
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteBookAsync([FromQuery] DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}