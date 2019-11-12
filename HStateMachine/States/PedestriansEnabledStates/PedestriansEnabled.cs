using System;
using System.Collections.Generic;
using System.Text;

using HStateMachine.States.VehiclesEnabledStates;
namespace HStateMachine.States.PedestriansEnabledStates
{
    public class PedestriansEnabled : HState<TrafficLightSignal, TrafficLightContext, PedestriansEnabledContext>
    {
        protected override IHSM<TrafficLightSignal, PedestriansEnabledContext> InternalHSM { get; } = new HSM<TrafficLightSignal, PedestriansEnabledContext>();

        public PedestriansEnabled(TrafficLightContext context):base(context)
        {
            InternalHSM.SetInitialState(new PedestriansWalk(new PedestriansEnabledContext {Model = Context.Model}));
        }
        protected override void OnEnter()
        {
            Context.Model.SignalVehicles(COLOR.RED);
        }

        protected override void OnExit(){}

        protected override IHState<TrafficLightSignal, TrafficLightContext> OnSignal(TrafficLightSignal s)
        {
            switch (s)
            {
                case TrafficLightSignal.PED_TIMEOUT:
                    return new VehiclesEnabled(Context);
                default:
                    return null;
            }
        }
    }
}
