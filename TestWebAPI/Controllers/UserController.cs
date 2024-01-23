using TestWebAPI.Model;
using TestWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public IActionResult Create([FromBody] UserModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
            {
                throw new BadHttpRequestException($"Invalid data. Both first name and last name are required.", StatusCodes.Status400BadRequest);

            }
            _userService.SaveUserToFile(model);
            return CreatedAtAction(null, null, model);
        }
    }
}
