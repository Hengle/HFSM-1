using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace HStateMachine
{
    public abstract class HState<SIG, CTX> : HState<SIG, CTX, CTX>
    {
        protected override IHSM<SIG, CTX> InternalHSM { get; }
        public HState(CTX context):base(context)
        {
            Context = context;
        }
    }

    public abstract class HState<SIG, CTX, ICTX> : IHState<SIG, CTX> where ICTX:CTX
    {
        protected abstract IHSM<SIG, ICTX> InternalHSM { get; }
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
        }

        public IHState<SIG, CTX> Handle(SIG s)
        {
            if (InternalHSM?.Handle(s) ?? false)
            {
                return this; // If the internal HSM could handle the signal, then we return ourselves to signify an internal transition.
            }
            else
            {
                // Otherwise consult our OnSignal to determine if we should transition to a state in the same context or pass it further up.
                return OnSignal(s);
            }
        }
        /// <summary>
        /// Called as a part of the entering process.
        /// </summary>
        protected abstract void OnEnter();
        /// <summary>
        /// Called as a part of the exiting process.
        /// </summary>
        protected abstract void OnExit();

        /// <summary>
        /// Handle the signal if possible.
        /// </summary>
        /// <param name="s">The signal to handle.</param>
        /// <returns>The state to transition to, null if unhandled.</returns>
        protected abstract IHState<SIG, CTX> OnSignal(SIG s);
    }
}
