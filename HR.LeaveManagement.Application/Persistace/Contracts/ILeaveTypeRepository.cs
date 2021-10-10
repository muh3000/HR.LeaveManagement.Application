using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistace.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
    }
}
