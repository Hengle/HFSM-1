using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{
    public interface IHState<CTX>
    {
        public interface IHandle<ARG> where ARG : EventArgs
        {
            IHState<CTX> HandleEvent(ARG args);
        }
    //public interface IHandle<ARG> : IHandle<CTX, ARG> where ARG : EventArgs{}
        public void Enter();
        public void Exit();
        public IHState<CTX> Handle<Args>(Args args) where Args : EventArgs;
    }
}
