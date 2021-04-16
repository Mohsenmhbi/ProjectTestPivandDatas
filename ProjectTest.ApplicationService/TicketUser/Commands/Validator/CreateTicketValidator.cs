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
            RuleFor(c => c.Description).NotEmpty().
                WithMessage("توضیحات نباید خالی باشد")
                .MaximumLength(1000).WithMessage("حد اکثر نباید بیشتر از 1000 کاراکتر باشد")
                .MinimumLength(3).WithMessage("حدالقل نباید کمتر از 40 کاراکتر باشد")
                .NotNull();
               
        }
    }
}
