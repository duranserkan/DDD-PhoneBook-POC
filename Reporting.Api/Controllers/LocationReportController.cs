using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reporting.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LocationReportController : ControllerBase
	{
		private readonly ILogger<LocationReportController> _logger;

		public LocationReportController(ILogger<LocationReportController> logger)
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
