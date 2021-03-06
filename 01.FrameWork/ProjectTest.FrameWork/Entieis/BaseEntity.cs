using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.FrameWork.Entieis
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; }
        private Action<IEvent> _applier;
        public BaseEntity(Action<IEvent> applier)
        {
            _applier = applier;

        }
        protected BaseEntity() { }
        public void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            _applier(@event);
        }

        protected abstract void SetStateByEvent(IEvent @event);

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id.ToString() == default || other.Id.ToString() == default)
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }


    }
}
