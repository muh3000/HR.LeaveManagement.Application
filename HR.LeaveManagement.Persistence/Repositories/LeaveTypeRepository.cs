using HR.LeaveManagement.Application.Contracts.Persistace;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository :GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _leaveManagementDbContext;

        public LeaveTypeRepository(LeaveManagementDbContext leaveManagementDbContext):base(leaveManagementDbContext)
        {
            _leaveManagementDbContext = leaveManagementDbContext;
        }
    }
}
