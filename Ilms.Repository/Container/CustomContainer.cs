using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using Ilms.Repository.Factory;
using Ilms.Repository.Repository;
using Ilms.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repository;
namespace Ilms.Repository.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
		Ii3msConnectionFactory i3msconnectionFactory=new i3msConnectionFactory(configuration.GetConnectionString("DBconnectioni3ms"));
		services.AddSingleton<Ii3msConnectionFactory> (i3msconnectionFactory);

		services.AddScoped<ImodRepository, modRepository>();
		services.AddScoped<ICodeGenLoginRepository, CodeGenLoginRepository>();
		services.AddScoped<ISendSMSRepository, SendSMSRepository>();
			//Write code here
		}
	}
}
