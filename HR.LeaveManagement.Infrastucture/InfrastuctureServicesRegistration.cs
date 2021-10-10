using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Model;
using HR.LeaveManagement.Infrastucture.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Infrastucture
{
    public static class InfrastuctureServicesRegistration
    {

        public static IServiceCollection ConfigurationInfrastuctureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));


            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
