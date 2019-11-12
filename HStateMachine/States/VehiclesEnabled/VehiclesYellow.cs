using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabled
{
    class VehiclesYellow : HState<TrafficLightSignal, VehiclesEnabledContext>
    {
        public VehiclesYellow(VehiclesEnabledContext context) : base(context) { }
        protected override void OnEnter() 
        {
            timer = new System.Timers.Timer(3000);
            timer.Elapsed += (e, o) => Context.Model.Handle(TrafficLightSignal.TIMER_TIMEOUT);
        }

        protected override void OnExit()
        {
            throw new NotImplementedException();
        }

        protected override IHState<TrafficLightSignal, VehiclesEnabledContext> OnSignal(TrafficLightSignal s)
        {
            throw new NotImplementedException();
        }
    }
}
