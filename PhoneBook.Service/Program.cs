using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Infrastructure.DbContext;
using PhoneBook.Service.Modules;

namespace PhoneBook.Service
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddDbContext<PhoneBookDbContext>(options => options.UseNpgsql(hostContext.Configuration.GetConnectionString("PhoneBookDb")));
					services.AddRabbitMq(hostContext.Configuration);
				});
	}
}
