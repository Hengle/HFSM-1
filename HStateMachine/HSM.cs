using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{
    public class HSM<SIG, CTX> : IHSM<SIG, CTX>
    {
        private IHState<SIG, CTX> currentState;


        /// <summary>
        /// Handle an incoming signal.
        /// </summary>
        /// <param name="s">The signal to handle.</param>
        /// <returns>True if the signal was handled.</returns>
        public bool Handle(SIG s)
        {
            var nextState = currentState.Handle(s);
            if ((nextState != null)){
                TransitionTo(nextState);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetInitialState(IHState<SIG, CTX> initialState)
        {
            currentState = initialState;
        }

        /// <summary>
        /// Start this state machine. Enters the current state.
        /// </summary>
        public void Start()
        {
            currentState.Enter();
        }
        /// <summary>
        /// Stop this state machine. Exits the current state.
        /// </summary>
        public void Stop()
        {
            currentState.Exit();
        }
        /// <summary>
        /// Transition this HSM to a new state.
        /// </summary>
        /// <param name="state"> The state to transition to. </param>
        public void TransitionTo(IHState<SIG, CTX> state)
        {
            if(state != currentState)
            {
                currentState.Exit();

            }
        }
    }
}
