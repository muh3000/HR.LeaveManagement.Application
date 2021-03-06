
using HR.LeaveManagement.Application.Contracts.Persistace;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurationPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options => 
                options.UseSqlServer(
                        configuration.GetConnectionString("ConnectionString")));


            services.AddScoped( typeof(IGenericRepository<>),typeof(GenericRepository<>) ) ;
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository,  LeaveRequestRepository>();
            
            





            return services;
        }
    }
}
