using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<IdentityController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<IdentityController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.DTOs.LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Retorne um token JWT ou algum outro tipo de resposta
                    return Ok(new { Message = "Login successful" });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid login attempt" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao fazer login", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Models.DTOs.RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = new IdentityUser { UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "Registration successful" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("## Erro ao registrar o usuário", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            try
            {
                // Obtém o usuário atual usando o UserManager
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    // Retorna um status de Unauthorized se o usuário não estiver autenticado
                    return Unauthorized(new { Message = "User is not authenticated" });
                }

                // Retorna informações do usuário. Você pode adicionar mais propriedades se desejar.
                return Ok(new
                {
                    UserName = user.UserName  // Retorna o nome de usuário        // Retorna o e-mail do usuário
                                               // Adicione outras propriedades conforme necessário
                });
            }
            catch (Exception ex)
            {
                // Loga o erro e retorna uma resposta de erro do servidor
                _logger.LogError("## Error while retrieving current user", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}