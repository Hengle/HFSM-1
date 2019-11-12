using HStateMachine.States.PedestriansEnabledStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{
    public class VehiclesEnabled : HState<TrafficLightSignal, TrafficLightContext, VehiclesEnabledContext>
    {
        public VehiclesEnabled(TrafficLightContext ctx) : base(ctx){
            InternalHSM.SetInitialState(new VehiclesGreen(new VehiclesEnabledContext() { Model = Context.Model, PedestriansWaiting = false }));
        }
        protected override IHSM<TrafficLightSignal, VehiclesEnabledContext> InternalHSM { get; } = new HSM<TrafficLightSignal, VehiclesEnabledContext>();

        protected override void OnEnter()
        {
            Context.Model.SignalPedestrians(COLOR.RED);
            
            InternalHSM.Start();
        }

        protected override void OnExit()
        {
            
        }

        protected override IHState<TrafficLightSignal, TrafficLightContext> OnSignal(TrafficLightSignal s)
        {
            switch (s)
            {
                case TrafficLightSignal.YELLOW_TIMEOUT:
                    return new PedestriansEnabled(Context);
                default:
                    return null;
            }
        }
    }
}
