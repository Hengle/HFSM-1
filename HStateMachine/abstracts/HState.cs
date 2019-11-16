using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace HStateMachine
{
    public abstract class HState<CTX> : HState<CTX, CTX>
    {
        protected override IHSM<CTX> InternalHSM { get; }
        public HState(CTX context):base(context)
        {
            Context = context;
        }
    }

    public abstract class HState<CTX, ICTX> : IHState<CTX> where ICTX:CTX 
    {
        protected abstract IHSM<ICTX> InternalHSM { get; }
        protected CTX Context { get; set; }
        protected Timer timer;
        public HState(CTX context)
        {
            Context = context;
        }

        /// <summary>
        /// Enter this state.
        /// </summary>
        public void Enter(){
            System.Diagnostics.Debug.WriteLine($"Entered {GetType()}");
            // First enter the state
            OnEnter();
            // Then start the internal HSM if existing.
            InternalHSM?.Start(); 
        }
        public void Exit(){ 
            // Stop internal if existing
            InternalHSM?.Stop();
            // Exit this state.
            OnExit();
            System.Diagnostics.Debug.WriteLine($"Exited {GetType()}");
        }


        public IHState<CTX> Handle<Args>(Args args) where Args: EventArgs
        {
            if (InternalHSM?.Handle(args) ?? false)
            {
                return this; // If the internal HSM could handle the signal, then we return ourselves to signify an internal transition.
            }
            else
            {
                //Do we have a method to handle this? if not pass it further up by returning null.
                if (this is IHState<CTX>.IHandle<Args> handler)
                    return handler.HandleEvent(args);
                else
                    return null;
            }
        }
        /// <summary>
        /// Called as a part of the entering process.
        /// </summary>
        protected virtual void OnEnter() { }


        /// <summary>
        /// Called as a part of the exiting process.
        /// </summary>
        protected virtual void OnExit() { }

    }
}
