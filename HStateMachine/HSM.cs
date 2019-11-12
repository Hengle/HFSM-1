using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HStateMachine
{
    public class HSM<SIG, CTX> : IHSM<SIG, CTX>
    {
        private bool running;
        private IHState<SIG, CTX> currentState;


        /// <summary>
        /// Handle an incoming signal.
        /// </summary>
        /// <param name="s">The signal to handle.</param>
        /// <returns>True if the signal was handled.</returns>
        public bool Handle(SIG s)
        {
            Debug.WriteLine($"{GetType()} Handle {s.ToString()}");
            // If the transitions could be handled then transition to the new state.
            var newState = currentState.Handle(s);
            if ((newState != null)){
                TransitionTo(newState);
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
            if (!running)
            {
                running = true;
                System.Diagnostics.Debug.WriteLine($"Starting {GetType()}");
                currentState.Enter();
            }
            else
            {
                throw new Exception("HSM is already running!");
            }
        }
        /// <summary>
        /// Stop this state machine. Exits the current state.
        /// </summary>
        public void Stop()
        {
            if (running)
            {
                running = false;
                System.Diagnostics.Debug.WriteLine($"Stopping {GetType()}");
                currentState.Exit();
            }
            else
            {
                throw new Exception("HSM is already stopped!");
            }
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
                currentState = state;
                currentState.Enter();
            }
        }
    }
}
