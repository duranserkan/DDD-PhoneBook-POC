using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Infrastructure.DbContext;
using PhoneBook.Service.Modules;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;

namespace PhoneBook.Service
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.WriteTo.Graylog(new GraylogSinkOptions
				{
					HostnameOrAddress = "localhost",
					Port = 12201
				})
				.CreateLogger();

			try
			{
				Log.Information("Starting web host");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog()
				.ConfigureServices((hostContext, services) =>
				{
					services.AddDbContext<PhoneBookDbContext>(options => options.UseNpgsql(hostContext.Configuration.GetConnectionString("PhoneBookDb")));
					services.AddApplicationServices();
					services.AddRabbitMq(hostContext.Configuration);
				});
	}
}
