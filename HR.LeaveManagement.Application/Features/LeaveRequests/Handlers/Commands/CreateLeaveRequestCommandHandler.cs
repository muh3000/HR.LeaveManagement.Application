using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistace.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

       

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var reponse = new BaseCommandResponse();

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            //Exception way
            //if (!validationResult.IsValid)
            //    throw new Exceptions.ValidationException(validationResult);

            if (!validationResult.IsValid)
            {
                reponse.Success = false;
                reponse.Message = "Creation Failed";
                reponse.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
                


            var leaveRequest = await _leaveRequestRepository.Add(_mapper.Map<LeaveRequest>(request.LeaveRequestDto));
            reponse.Success = true;
            reponse.Message = "Creation Successful";
            reponse.Id = leaveRequest.Id;

            return reponse;

        }
    }
}
