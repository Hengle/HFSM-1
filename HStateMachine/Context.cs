using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{
    class Context
    {
    }
    public class TrafficLightContext
    {
        public TrafficLight Model { get; set; }
    }

    public class VehiclesEnabledContext : TrafficLightContext
    {
        public bool PedestriansWaiting { get; set; }
        public TrafficLightContext Base { get => new TrafficLightContext { Model = Model }; }
    }

    class PedestrianContext : TrafficLightContext
    {
        public int flashCount = 7;
    }
}
