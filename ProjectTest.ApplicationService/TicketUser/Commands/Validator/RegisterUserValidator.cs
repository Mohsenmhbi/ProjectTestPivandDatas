using FluentValidation;
using ProjectTest.ApplicationService.TicketUser.Commands;
using ProjectTest.CoreDomain.UserProfile.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.ApplicationService.TicketUser.Validator
{
    public class RegisterUserValidator: AbstractValidator<CreateTicket>
    {


        public RegisterUserValidator(IUserProfileRepository userProfileRepository)
        {


               RuleFor(c => c.UserResiveId).NotEmpty().When(b=>
                !userProfileRepository.Exists(b.UserResiveId)).WithMessage(c => $"قبلا کاربری با شناسه {c.UserResiveId} ثبت شده است.");

            RuleFor(c => c.UserSenderId).NotEmpty().When(b =>
                   !userProfileRepository.Exists(b.UserSenderId)).WithMessage(c => $"قبلا کاربری با شناسه {c.UserSenderId} ثبت شده است.");
        }
      
    }

}
