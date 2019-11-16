using System;
using System.Collections.Generic;
using System.Text;

using HStateMachine.States.VehiclesEnabledStates;

namespace HStateMachine.States.PedestriansEnabledStates
{

    using static IHState<TrafficLightContext>;
    public class PedestriansEnabled : HState<TrafficLightContext, PedestriansEnabledContext>, IHandle<PedestrianTimeout>
    {
        protected override IHSM<PedestriansEnabledContext> InternalHSM { get; } = new HSM<PedestriansEnabledContext>();

        public PedestriansEnabled(TrafficLightContext context):base(context)
        {
            InternalHSM.SetInitialState(new PedestriansWalk(new PedestriansEnabledContext {Model = Context.Model}));
        }
        protected override void OnEnter()
        {
            Context.Model.SignalVehicles(COLOR.RED);
        }

        public IHState<TrafficLightContext> HandleEvent(PedestrianTimeout args)
        {
            return new VehiclesEnabled(Context);
        }
    }
}
