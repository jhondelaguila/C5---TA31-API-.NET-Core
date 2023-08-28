using Microsoft.EntityFrameworkCore;
using ex2.Data;

namespace ex2
{
    
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDbContext<APIContext>(opt => opt.UseInMemoryDatabase("APIList"));
            services.AddControllers();
            services.AddSwaggerGen();
        }
    }
}
