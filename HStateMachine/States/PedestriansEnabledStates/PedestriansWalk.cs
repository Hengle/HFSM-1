using System;
using System.Collections.Generic;
using System.Text;


namespace HStateMachine.States.PedestriansEnabledStates
{
    using static HStateMachine.IHState<PedestriansEnabledContext>;
    public class PedestriansWalk : HState<PedestriansEnabledContext>, IHandle<PedestrianTimeout>
    {
        public PedestriansWalk(PedestriansEnabledContext context) : base(context) { }

        public IHState<PedestriansEnabledContext> HandleEvent(PedestrianTimeout args)
        {
            return new PedestriansFlash(Context);
        }

        protected override void OnEnter()
        {
            Context.Model.SignalPedestrians(COLOR.GREEN);
            timer = new System.Timers.Timer(4000);
            timer.Elapsed += (e, o) => Context.Model.Handle(new PedestrianTimeout());
            timer.Start();
        }

        protected override void OnExit()
        {
            timer.Stop();
        }
    }
}
