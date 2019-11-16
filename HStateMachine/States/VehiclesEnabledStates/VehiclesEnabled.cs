using HStateMachine.States.PedestriansEnabledStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{

    using static HStateMachine.IHState<TrafficLightContext>;
    public class VehiclesEnabled : HState<TrafficLightContext, VehiclesEnabledContext>, IHandle<YellowTimeout>
    {
        
        public VehiclesEnabled(TrafficLightContext ctx) : base(ctx){
            InternalHSM.SetInitialState(new VehiclesGreen(new VehiclesEnabledContext() { Model = Context.Model, PedestriansWaiting = false }));
        }
        protected override IHSM<VehiclesEnabledContext> InternalHSM { get; } = new HSM<VehiclesEnabledContext>();

        public IHState<TrafficLightContext> HandleEvent(YellowTimeout args)
        {
            return new PedestriansEnabled(Context);
        }

        protected override void OnEnter()
        {
            Context.Model.SignalPedestrians(COLOR.RED);
        }
    }
}
