using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonController : ControllerBase
	{
		private readonly ILogger<PersonController> _logger;

		public PersonController(ILogger<PersonController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}
	}
}
