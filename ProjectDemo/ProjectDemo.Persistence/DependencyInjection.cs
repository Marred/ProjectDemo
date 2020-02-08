using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ProjectDemo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDemoDbContext>(options => options.UseInMemoryDatabase("ProjectsDb"));
            return services;
        }
    }
}
