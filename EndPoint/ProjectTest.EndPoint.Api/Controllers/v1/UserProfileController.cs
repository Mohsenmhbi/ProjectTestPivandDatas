using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.ApplicationService.UserProfiles.Commands;
using ProjectTest.ApplicationService.UserProfiles.Handlers;

namespace ProjectTest.EndPoint.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name =nameof(RegisterUser))]
        public IActionResult RegisterUser([FromServices] RegisterUserHandler handler, RegisterUserProfile request)
        {
            _mediator.Send(request);
            return Ok();
        }
    }
}