﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine.States.VehiclesEnabled
{
    class VehiclesGreen : HState<TrafficLightSignal, VehiclesEnabledContext>
    {
        public VehiclesGreen(VehiclesEnabledContext context):base(context){}
        protected override void OnEnter()
        {
            timer = new System.Timers.Timer(4000);
            timer.Elapsed += (e, v) => Context.Model.Handle(TrafficLightSignal.TIMER_TIMEOUT);
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
                case TrafficLightSignal.TIMER_TIMEOUT:
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
