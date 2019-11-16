using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{

    using static HStateMachine.IHState<VehiclesEnabledContext>;
    public class VehiclesGreen : HState<VehiclesEnabledContext>, IHandle<GreenTimeout>, IHandle<PedestrianWaiting>
    {
        public VehiclesGreen(VehiclesEnabledContext context):base(context){}

        public IHState<VehiclesEnabledContext> HandleEvent(GreenTimeout args)
        {
            if (Context.PedestriansWaiting)
                return new VehiclesYellow(Context);
            else
                return new VehiclesGreenInt(Context);
        }

        public IHState<VehiclesEnabledContext> HandleEvent(PedestrianWaiting args)
        {
            Context.PedestriansWaiting = true;
            return this;
        }

        protected override void OnEnter()
        {
            Context.Model.SignalVehicles(COLOR.GREEN);
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += (e, v) => { System.Diagnostics.Debug.WriteLine("Green timeout!");  Context.Model.Handle(new GreenTimeout()); };
            timer.Start();
        }

        protected override void OnExit()
        {
            timer.Stop();
        }
    }
}
