using System;
using System.Linq.Expressions;

namespace ProjectTest.CoreDomain.UserProfile.Data
{
    public interface IUserProfileRepository
    {
        UserProfile.Entitie.UserProfile Load(Guid id);
        void Add(UserProfile.Entitie.UserProfile entity);
        bool Exists(int id);
    }
}
