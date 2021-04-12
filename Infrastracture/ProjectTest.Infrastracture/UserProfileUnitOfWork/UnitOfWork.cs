using ProjectTest.FrameWork.Data;
using ProjectTest.Infrastracture.Context;

namespace ProjectTest.Infrastracture.UserProfileUnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly TestContext _context;

        public UnitOfWork(TestContext context)
        {
            _context = context;
        }

        public int Commit()
        {
           return _context.SaveChanges();
        }
    }
}
