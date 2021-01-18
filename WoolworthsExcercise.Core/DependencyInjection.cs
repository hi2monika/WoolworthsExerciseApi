using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WoolworthsExcercise.Core.Behaviors;
using WoolworthsExcercise.Core.Common.Interfaces.Services;
using WoolworthsExcercise.Core.Services;

namespace WoolworthsExcercise.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            serviceCollection.AddScoped<ITrolleyService, TrolleyService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            return serviceCollection;
        }
    }
}
