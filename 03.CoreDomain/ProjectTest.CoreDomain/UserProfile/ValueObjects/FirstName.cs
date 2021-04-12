using ProjectTest.FrameWork.ValueObjects;
using System;

namespace ProjectTest.CoreDomain.UserProfile.ValueObjects
{
    public class FirstName : BaseValueObject<FirstName>
    {

        public string Value { get; private set; }
        public static FirstName FromString(string value) => new FirstName(value);
        private FirstName()
        {

        }
        public FirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("فیلد نام نمیتواند خالی باشد", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(FirstName otherObject) => Value == otherObject.Value;

        public static implicit operator string(FirstName firstName) => firstName.Value;
    }
}
