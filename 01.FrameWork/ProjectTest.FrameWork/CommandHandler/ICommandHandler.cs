using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.FrameWork.CommandHandler
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
