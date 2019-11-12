using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.PedestriansEnabledStates
{
    class PedestriansFlash : HState<TrafficLightSignal, PedestriansEnabledContext>
    {
        int flashCount = 7;

        public PedestriansFlash(PedestriansEnabledContext context) : base(context) { }
        protected override void OnEnter()
        {
            timer = new System.Timers.Timer(1500);
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
                    flashCount--;
                    if (flashCount == 0)
                    {
                        return null;
                    }
                    else if ((flashCount & 1) == 0)
                    {
                        Context.Model.SignalPedestrians(COLOR.BLANK);
                        return this;
                    }
                    else
                    {
                        Context.Model.SignalPedestrians(COLOR.GREEN);
                        return this;
                    }
                default:
                    return null;
            }
        }
    }
}
