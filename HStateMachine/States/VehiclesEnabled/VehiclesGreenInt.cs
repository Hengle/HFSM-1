using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabled
{
    class VehiclesGreenInt:HState<TrafficLightSignal, VehiclesEnabledContext>
    {
        public VehiclesGreenInt(VehiclesEnabledContext context) : base(context) { }

        protected override void OnEnter()
        {
            throw new NotImplementedException();
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
