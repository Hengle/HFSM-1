using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.PedestriansEnabledStates
{
    public class PedestriansWalk : HState<TrafficLightSignal, PedestriansEnabledContext>
    {
        public PedestriansWalk(PedestriansEnabledContext context) : base(context) { }
        protected override void OnEnter()
        {
            Context.Model.SignalPedestrians(COLOR.GREEN);
            timer = new System.Timers.Timer(4000);
            timer.Elapsed += (e, o) => Context.Model.Handle(TrafficLightSignal.PED_TIMEOUT);
            timer.Start();
        }

        protected override void OnExit()
        {
            timer.Stop();
        }

        protected override IHState<TrafficLightSignal, PedestriansEnabledContext> OnSignal(TrafficLightSignal s)
        {
            switch (s)
            {
                case TrafficLightSignal.PED_TIMEOUT:
                    return new PedestriansFlash(Context);
                default:
                    return null;
            }
        }
    }
}
