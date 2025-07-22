using BookReview.Core.DTO;
using BookReview.Core.ServicesContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        [Authorize] // Asegúrate de que este endpoint solo sea accesible para usuarios autenticados
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _userService.GetCurrentUserProfileAsync();
            if (profile == null)
                return NotFound("Usuario no encontrado o no autenticado.");

            return Ok(profile);
        }
    }
}
