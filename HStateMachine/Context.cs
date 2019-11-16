using HStateMachine.abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{

    public class TrafficLightContext : Context
    {
        public TrafficLight Model { get; set; }
    }

    public class VehiclesEnabledContext : TrafficLightContext
    {
        public bool PedestriansWaiting { get; set; }
        public TrafficLightContext Base { get => new TrafficLightContext { Model = Model }; }
    }

    public class PedestriansEnabledContext : TrafficLightContext
    {
    }
}
