using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Reporting.Api.Controllers
{
	[ApiController]
	[Route("")]
	public class HealthCheckController : ControllerBase
	{
		private readonly ILogger<HealthCheckController> _logger;

		public HealthCheckController(ILogger<HealthCheckController> logger)
		{
			_logger = logger;
		}

		[HttpGet("healthcheck")]
		public async Task<IActionResult> HealthCheck()
		{
			return Ok(Environment.MachineName);
		}
	}
}
