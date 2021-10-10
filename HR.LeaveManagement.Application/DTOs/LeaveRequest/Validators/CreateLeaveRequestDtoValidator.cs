﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistace;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {

            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExist;
                }).WithMessage("{PropertyName} does not exist.");


        }
    }
}
