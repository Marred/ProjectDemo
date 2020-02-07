using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ProjectDemo.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDemoDbContext>(options => options.UseInMemoryDatabase("ProjectsDb"));
            return services;
        }
    }
}
