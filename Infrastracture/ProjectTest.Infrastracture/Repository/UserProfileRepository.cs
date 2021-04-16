using ProjectTest.CoreDomain.UserProfile.Data;
using ProjectTest.CoreDomain.UserProfile.Entitie;
using ProjectTest.Infrastracture.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectTest.Infrastracture.Repository
{
    public class UserProfileRepository : IUserProfileRepository, IDisposable
    {

        private readonly TestContext _context;

        public UserProfileRepository(TestContext context)
        {
            _context = context;
        }

        public void Add(UserProfile entity)
        {
            _context.userProfiles.Add(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Exists(int id)
        {
            return _context.userProfiles.Any(c=>c.Id==id);
        }

        public UserProfile Load(Guid id)
        {
            return _context.userProfiles.Find(id);
        }
    }
}

