using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Application.Services;
using PhoneBook.Contract.Requests.Contact;
using PhoneBook.Domain.ContactAggregate;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PhoneBook.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ContactController : ControllerBase
	{
		private readonly ILogger<ContactController> _logger;
		private readonly IContactService _contactService;

		public ContactController(ILogger<ContactController> logger, IContactService iContactService)
		{
			_logger = logger;
			_contactService = iContactService;
		}

		[HttpGet("{contactId}")]
		public async Task<IActionResult> Get([FromRoute] Guid contactId)
		{
			if (contactId == default)
				return BadRequest();

			var response = await _contactService.GetContactAsync(contactId);

			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] PageFilter pageFilter)
		{
			var validFilter = new PageFilter(pageFilter.PageNumber, pageFilter.PageSize);
			var response = await _contactService.GetContactsAsync(validFilter);

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PostContactRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Content) ||
			    !Enum.IsDefined(typeof(ContactType), request.ContactType))
				return BadRequest();

			await _contactService.SaveAsync(request);

			return StatusCode((int)HttpStatusCode.Created);
		}


		[HttpDelete("{contactId}")]
		public async Task<IActionResult> Delete([FromRoute] Guid contactId)
		{
			if (contactId == default)
				return BadRequest();

			var person = await _contactService.DeleteContactAsync(contactId);

			return person == null ? (IActionResult) NotFound() : Ok();
		}
	}
}
