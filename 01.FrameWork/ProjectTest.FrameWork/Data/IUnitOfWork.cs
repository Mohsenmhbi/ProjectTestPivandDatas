using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.FrameWork.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
