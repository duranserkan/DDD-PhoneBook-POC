using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Application.Services;
using PhoneBook.Contract.Requests.Phone;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PhoneBook.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly ILogger<PersonController> _logger;
		private readonly IPersonService _personService;

		public PersonController(ILogger<PersonController> logger, IPersonService personService)
		{
			_logger = logger;
			_personService = personService;
		}

		[HttpGet("{personId}")]
		public async Task<IActionResult> Get([FromRoute] Guid personId)
		{
			if (personId == default)
				return BadRequest();

			var response = await _personService.GetPersonAsync(personId);

			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] PageFilter pageFilter)
		{
			var validFilter = new PageFilter(pageFilter.PageNumber, pageFilter.PageSize);
			var response = await _personService.GetPeopleAsync(validFilter);

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PostPersonRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Name) ||
				string.IsNullOrWhiteSpace(request.Surname))
				return BadRequest();

			await _personService.SaveAsync(request);

			return StatusCode((int)HttpStatusCode.Created);
		}

		[HttpPatch("{personId}")]
		public async Task<IActionResult> Patch([FromRoute] Guid personId, [FromBody] PatchPersonRequest request)
		{
			if (personId == default)
				return BadRequest();

			request.PersonId = personId;

			await _personService.PatchAsync(request);

			return Ok();
		}

		[HttpDelete("{personId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid personId)
		{
			if (personId == default)
				return BadRequest();

			var person = await _personService.DeletePersonAsync(personId);

			return person == null ? (IActionResult) NotFound() : Ok();
		}
	}
}
