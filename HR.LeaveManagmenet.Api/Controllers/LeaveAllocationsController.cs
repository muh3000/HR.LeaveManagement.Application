using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveAllocationDetailRequest() { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LeaveAllocationDto leaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand() { LeaveAllocationDto = leaveAllocationDto };
            var reponse = await _mediator.Send(command);
            return Ok(reponse);


        }

        // PUT api/<LeaveTypesController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveAllocationDto leaveAllocationDto)
        {
            throw new NotImplementedException();
            //var command = new UpdateLeaveTypeCommand() { LeaveTypeDto = leaveType };
            //await _mediator.Send(command);
            //return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
            //var command = new DeleteLeaveTypeCommand() { Id = id };
            //await _mediator.Send(command);
            //return NoContent();
        }
    }
}
