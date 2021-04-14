using FluentValidation;
using ProjectTest.ApplicationService.TicketUser.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.ApplicationService.TicketUser.Validator
{
    public class CreateTicketValidator:AbstractValidator<CreateTicket>
    {
        public CreateTicketValidator()
        {
            RuleFor(c => c.Description).NotEmpty()
                .NotNull()
                .MaximumLength(1000);
        }
    }
}
