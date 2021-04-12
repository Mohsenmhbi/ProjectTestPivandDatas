using ProjectTest.FrameWork.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.ValueObjects
{
    public class Title : BaseValueObject<Title>
    {

        public string Value { get; private set; }
        public static Title FromString(string value) => new Title(value);
        private Title()
        {

        }
        public Title(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("فیلد عنوان نمیتواند خالی باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Title otherObject) => Value == otherObject.Value;

        public static implicit operator string(Title firstName) => firstName.Value;
    }
}
