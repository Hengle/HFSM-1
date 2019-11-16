using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{
    class VehiclesYellow : HState<VehiclesEnabledContext>
    {
        public VehiclesYellow(VehiclesEnabledContext context) : base(context) { }
        protected override void OnEnter() 
        {
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += (e, o) => Context.Model.Handle(new YellowTimeout());
            timer.Start();
            Context.Model.SignalVehicles(COLOR.YELLOW);
        }

        protected override void OnExit()
        {
            timer.Stop();
        }
    }
}
