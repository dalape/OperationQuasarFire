using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OperationQuasarFire.Business.Interfaces;
using OperationQuasarFire.Model;
using OperationQuasarFire.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationQuasarFire.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunicationController : ControllerBase
    {
        private readonly IOperationBase _operationBaseService;

        public CommunicationController(IOperationBase operationBaseService) => _operationBaseService = operationBaseService;


        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> Topsecret(List<Satelite> satellites)
        {
            IResponseService response = await _operationBaseService.TriangularPosition(satellites);
            if (response.Meta.Status && response.Meta.HttpStatus == MessagesEnum.HttpStateUnauthorized) return Unauthorized();
            if (response.Meta.Status) return Ok(response);
            ModelState.AddModelError(MessagesEnum.Error, string.Join(",", response.Meta.Errors));
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost("[action]/{satelliteName}")]
        public async Task<IActionResult> TopSecretSplit(string satelliteName, [FromBody] SateliteSplit satellite)
        {
            IResponseService response = await _operationBaseService.SaveSateliteInformation(new Satelite { Name = satelliteName, Distance = satellite.Distance, Message = satellite.Message });
            if (response.Meta.Status && response.Meta.HttpStatus == MessagesEnum.HttpStateUnauthorized) return Unauthorized();
            if (response.Meta.Status) return Ok(response);
            ModelState.AddModelError(MessagesEnum.Error, string.Join(",", response.Meta.Errors));
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> TopSecretSplit()
        {
            IResponseService response = await _operationBaseService.TriangularPosition();
            if (response.Meta.Status && response.Meta.HttpStatus == MessagesEnum.HttpStateUnauthorized) return Unauthorized();
            if (response.Meta.Status) return Ok(response);
            ModelState.AddModelError(MessagesEnum.Error, string.Join(",", response.Meta.Errors));
            return BadRequest(ModelState);
        }
    }
}
