﻿using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Modules;

namespace PhoneBook.Api.Controllers
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
		public IActionResult HealthCheck()
		{
			return Ok(Environment.MachineName);
		}
	}
}
