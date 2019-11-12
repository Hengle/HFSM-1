using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabledStates
{
    class VehiclesGreen : HState<TrafficLightSignal, VehiclesEnabledContext>
    {
        public VehiclesGreen(VehiclesEnabledContext context):base(context){}
        protected override void OnEnter()
        {
            Context.Model.SignalVehicles(COLOR.GREEN);
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += (e, v) => { System.Diagnostics.Debug.WriteLine("Green timeout!");  Context.Model.Handle(TrafficLightSignal.GREEN_TIMEOUT); };
            timer.Start();
        }

        protected override void OnExit()
        {
            timer.Stop();
        }

        protected override IHState<TrafficLightSignal, VehiclesEnabledContext> OnSignal(TrafficLightSignal s)
        {
            switch (s)
            {
                case TrafficLightSignal.PEDESTRIAN_WAITING:
                    Context.PedestriansWaiting = true;
                    return this;
                case TrafficLightSignal.GREEN_TIMEOUT:
                    if (Context.PedestriansWaiting)
                        return new VehiclesYellow(Context);
                    else
                        return new VehiclesGreenInt(Context);
                default:
                    return null;
            }
        }
    }
}
