using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectDemo.Application.Behaviours;
using System.Linq;
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

            var openGenericType = typeof(IValidator<>);

            var query =
                        from type in Assembly.GetExecutingAssembly().GetTypes()
                        let interfaces = type.GetInterfaces()
                        let genericInterfaces = interfaces.Where(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == openGenericType)
                        let matchingInterface = genericInterfaces.FirstOrDefault()
                        where matchingInterface != null
                        select new { matchingInterface, type };

            foreach (var pair in query)
            {
                services.Add(ServiceDescriptor.Transient(pair.matchingInterface, pair.type));
            }

            return services;
        }
    }
}
