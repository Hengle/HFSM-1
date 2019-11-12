using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{
    public interface IHState<SIG, CTX>
    {
        public void Enter();
        public void Exit();
        public IHState<SIG, CTX> Handle(SIG s);
    }
}
