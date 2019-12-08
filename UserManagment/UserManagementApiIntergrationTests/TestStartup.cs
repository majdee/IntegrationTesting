using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using UserManagementAPI;

namespace UserManagementApiIntegrationTests
{
    public class TestStartup : Startup
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            AddInMemoryDbContext(services);
        }

        private void AddInMemoryDbContext(IServiceCollection services)
        {
            // Remove the app's ApplicationDbContext registration.
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UserManagementDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add ApplicationDbContext using an in-memory database for testing.
            services.AddDbContext<UserManagementDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: $"InMemoryDbForTesting"));
        }
    }
}