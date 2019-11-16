using System;
using System.Collections.Generic;
using System.Text;
using HStateMachine.abstracts;

namespace HStateMachine.States.PedestriansEnabledStates
{
    using static IHState<PedestriansEnabledContext>;
    public class PedestriansFlash : HState<PedestriansEnabledContext>, IHandle<PedestrianTimeout>
    {
        int flashCount = 7;

        public PedestriansFlash(PedestriansEnabledContext context) : base(context) { }

        protected override void OnEnter()
        {
            timer = new System.Timers.Timer(1500);
            timer.Elapsed += (e, o) => Context.Model.Handle(new PedestrianTimeout());
            timer.Start();
        }

        protected override void OnExit()
        {
            timer.Stop();
        }

        public IHState<PedestriansEnabledContext> HandleEvent(PedestrianTimeout args)
        {
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
        }
    }
}
