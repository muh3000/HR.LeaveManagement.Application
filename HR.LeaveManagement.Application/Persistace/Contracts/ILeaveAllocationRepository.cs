using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistace.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        //Task Add(LeaveAllocation leaveAllocation);
    }
}
