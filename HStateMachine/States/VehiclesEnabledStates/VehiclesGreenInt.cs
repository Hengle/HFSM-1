using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{

    using static HStateMachine.IHState<VehiclesEnabledContext>;
    class VehiclesGreenInt:HState<VehiclesEnabledContext>, IHandle<PedestrianWaiting>
    {
        public VehiclesGreenInt(VehiclesEnabledContext context) : base(context) { }

        public IHState<VehiclesEnabledContext> HandleEvent(PedestrianWaiting args)
        {
            return new VehiclesYellow(Context);
        }
        protected override void OnEnter(){ Console.WriteLine("Waiting for pedestrian walk signal"); }
    }
}
