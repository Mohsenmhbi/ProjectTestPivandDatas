using ProjectTest.CoreDomain.UserProfile.Events;
using ProjectTest.CoreDomain.UserProfile.ValueObjects;
using ProjectTest.FrameWork.Entieis;
using ProjectTest.FrameWork.Events;
using ProjectTest.FrameWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.UserProfile.Entitie
{
   public class UserProfile: BaseAggregateRoot<int>
    {
        #region Fields
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public bool IsAdmin { get; private set; }
        #endregion





        #region Costructurs
        private UserProfile() { }

        public UserProfile( 
                          FirstName firstName,
                          LastName lastName,
                          Email email
                        )
        {
            HandleEvent(new UserRegistered
            {
               
                FirstName = firstName,
                LastName = lastName,
                Email= email
            });
        }
        #endregion


        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case UserRegistered e:
                    FirstName = FirstName.FromString(e.FirstName);
                    LastName = LastName.FromString(e.FirstName);
                    Email = Email.FromString(e.Email);
                    break;
                default:
                    break;
            }
        }

        protected override void ValidateInvariants()
        {
            var isValid = LastName != null
                       && FirstName != null
                       && Email != null;
                   
              
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"Invalid User");
            }
        }
    }
}
