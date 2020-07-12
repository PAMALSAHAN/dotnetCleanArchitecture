
using System.Reflection; //assembly
using Application.common.behaviors; //validate behavior eka thma wenas wenaa eka.
using FluentValidation; //addvalidatorsfromassembly
using MediatR;  //Ipiplinebehavior
using Microsoft.Extensions.DependencyInjection;  //iservicecollection

namespace Application
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        } 
    }
}