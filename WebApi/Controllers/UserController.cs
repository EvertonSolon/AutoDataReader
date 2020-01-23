using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;
using WebApi.Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public UserController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost(Name = "Create")]
        public ActionResult Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.Create(user);

            return Created($"/api/user/{user.Id}", user);
        }
    }
}