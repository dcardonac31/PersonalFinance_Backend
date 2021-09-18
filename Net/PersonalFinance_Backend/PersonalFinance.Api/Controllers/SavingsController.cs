using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalFinance.Api.Models;
using PersonalFinance.Common.Dtos;
using PersonalFinance.Common.Enums;
using PersonalFinance.Common.Enums.Exts;
using PersonalFinance.Domain.Dtos;
using PersonalFinance.Domain.Interfaces;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PersonalFinance.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly ILogger<SavingsController> _logger;
        private readonly ISavingService _service;
        private readonly IBrowserDetector _browserDetector;

        public SavingsController(ILogger<SavingsController> logger, ISavingService service, IBrowserDetector browserDetector)
        {
            _logger = logger;
            _service = service;
            _browserDetector = browserDetector;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseService<SavingDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            _logger.LogInformation(nameof(GetByIdAsync));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _service.GetByIdAsync(id).ConfigureAwait(false);
            var existResult = result != null;
            var response = new ResponseService<SavingDto>
            {
                Status = existResult,
                Message = existResult ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = result
            };
            return Ok(response);
        }

        [HttpGet("{page:int}/{limit:int}")]
        [ProducesResponseType(typeof(ResponseService<IEnumerable<SavingDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync(int? page, int? limit)
        {
            _logger.LogInformation(nameof(GetAllAsync));

            var result = await _service.GetAllAsync(page ?? 1, limit ?? 1000, "Id").ConfigureAwait(false);
            var resultDtos = result as SavingDto[] ?? result.ToArray();

            var response = new ResponseService<IEnumerable<SavingDto>>
            {
                Status = resultDtos.Any(),
                Message = resultDtos.Any() ? GenericEnumerator.Status.Ok.ToStringAttribute() : GenericEnumerator.Status.Error.ToStringAttribute(),
                Data = resultDtos
            };

            return Ok(response);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseService<string>), (int)HttpStatusCode.Created)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(SavingModel))]
        public IActionResult Post([FromBody] SavingModel request)
        {
            _logger.LogInformation(nameof(Post));

            var objRequest = Mapper.Map<SavingDto>(request);
            objRequest.CreationUser = HttpContext.User.Identity?.Name;
            if (objRequest.CreationUser is null)
                objRequest.CreationUser = "dcardonac";

            objRequest.CreationDate = DateTime.Now;

            var (status, id) = _service.Post(objRequest);

            return Ok(new ResponseService<int>
            {
                Status = status,
                Data = status ? id : default
            });
        }

        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        [Produces(MediaTypeNames.Application.Json, Type = typeof(SavingModel))]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavingModel request)
        {
            _logger.LogInformation(nameof(PutAsync));

            if (id != request.Id)
                return BadRequest();

            var objRequest = Mapper.Map<SavingDto>(request);
            objRequest.ModificationUser = HttpContext.User.Identity?.Name;
            if (objRequest.ModificationUser is null)
                objRequest.ModificationUser = "dcardonac";

            objRequest.ModificationDate = DateTime.Now;

            var status = await _service.PutAsync(id, objRequest).ConfigureAwait(false);

            var response = new ResponseService<bool>
            {
                Status = status
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            var status = await _service.DeleteAsync(id).ConfigureAwait(false);

            var response = new ResponseService<bool>
            {
                Status = status
            };
            return Ok(response);
        }

        [HttpDelete("logic/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseService<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLogicAsync(int id)
        {
            _logger.LogInformation(nameof(DeleteAsync));

            var user = HttpContext.User.Identity?.Name;
            if (user is null)
                user = "dcardonac";

            DeletedInfo<int> info = new()
            {
                UserName = user,
                Id = id
            };

            var status = await _service.DeleteLogicAsync(info).ConfigureAwait(false);

            var response = new ResponseService<bool>
            {
                Status = status
            };

            return Ok(response);
        }

    }
}
