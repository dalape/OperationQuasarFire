using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model.Enums;
using System.Threading.Tasks;

namespace OperationQuasarFire.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AuthenticationController(IAuthentication authenticationService) => _authenticationService = authenticationService;

        [Authorize("BasicAuthentication")]
        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            IResponseService response = await _authenticationService.GetToken();
            if (response.Meta.Status && response.Meta.HttpStatus == MessagesEnum.HttpStateUnauthorized) return Unauthorized();
            if (response.Meta.Status) return Ok(response);
            ModelState.AddModelError(MessagesEnum.Error, string.Join(",", response.Meta.Errors));
            return BadRequest(ModelState);
        }
    }
}
