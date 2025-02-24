﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SecurityTest.Application.Behaviour;
using System.Reflection;

namespace SecurityTest.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return service;
        }
    }
}
