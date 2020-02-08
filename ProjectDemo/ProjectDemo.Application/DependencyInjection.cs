using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectDemo.Application.Behaviours;
using System.Reflection;

namespace ProjectDemo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

            return services;
        }

        public static IMvcBuilder AddValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation(v => v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            return mvcBuilder;
        }
    }
}
