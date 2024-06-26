using Palworld.RESTSharp.ProxyService.Database.SQLite;
using Palworld.RESTSharp.ProxyService.Database;
using Palworld.RESTSharp.ProxyServer;

namespace Palworld.RESTSharp.ProxyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfigurationSection palworldRESTSharpConfigSection = builder.Configuration.GetSection("PalworldRESTSharpProxyConfig");

            builder.Services.Configure<PalworldRESTSharpProxyConfig>(palworldRESTSharpConfigSection);
            builder.Services.AddSingleton(new DatabaseConfiguration("Data Source=Data\\localdata.db", new Dictionary<string, string>
            {
                { "InitialUserToken", palworldRESTSharpConfigSection["PalworldServerAdminPass"] }
            }));
            builder.Services.AddSingleton<IDataContext, SQLiteDatabaseContext>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IAuditRepository, AuditRepository>();
            builder.Services.AddSingleton<IUserManager, UserManager>();
            builder.Services.AddSingleton<IAuditManager, AuditManager>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.Services.GetService<IDataContext>().Setup();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.EnableFilter();
                });
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
