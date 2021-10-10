using HR.LeaveManagement.Application.Contracts.Persistace;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _leaveManagementDbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext leaveManagementDbContext) : base(leaveManagementDbContext)
        {
            _leaveManagementDbContext = leaveManagementDbContext;
        }

        

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _leaveManagementDbContext.LeaveAllocations.Include(p=>p.LeaveType).ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            var leaveAllocation = await _leaveManagementDbContext.LeaveAllocations.Include(p => p.LeaveType).FirstOrDefaultAsync(p=>p.Id == Id);

            return leaveAllocation;
        }
    }
}
