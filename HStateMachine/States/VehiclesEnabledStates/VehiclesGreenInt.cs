using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{
    class VehiclesGreenInt:HState<TrafficLightSignal, VehiclesEnabledContext>
    {
        public VehiclesGreenInt(VehiclesEnabledContext context) : base(context) { }

        protected override void OnEnter(){ Console.WriteLine("Waiting for pedestrian walk signal"); }
        protected override void OnExit(){}

        protected override IHState<TrafficLightSignal, VehiclesEnabledContext> OnSignal(TrafficLightSignal s)
        {
            switch (s)
            {
                case TrafficLightSignal.PEDESTRIAN_WAITING: return new VehiclesYellow(Context);
                default: return null;
            }
        }
    }
}
