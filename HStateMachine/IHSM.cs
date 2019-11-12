using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HStateMachine
{
    public interface IHSM<SIG, CTX>
    {
        /// <summary>
        /// Set the initial state of this state machine.
        /// </summary>
        /// <param name="initialState"></param>
        public void SetInitialState(IHState<SIG, CTX> initialState);

        /// <summary>
        /// Start this state machine. Enters the current state.
        /// </summary>
        public void Start();

        /// <summary>
        /// Stop this state machine. Exits the current state.
        /// </summary>
        public void Stop();
        /// <summary>
        /// Handle an incoming signal.
        /// </summary>
        /// <param name="s">The signal to handle.</param>
        /// <returns>True if the signal was handled.</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool Handle(SIG s);
        /// <summary>
        /// Transition this HSM to a new state.
        /// </summary>
        /// <param name="state"> The state to transition to. </param>
        public void TransitionTo(IHState<SIG, CTX> state);
    }
}
