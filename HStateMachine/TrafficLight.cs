using System;
using System.Collections.Generic;
using System.Text;
using HStateMachine.States.VehiclesEnabledStates;
namespace HStateMachine
{
    public enum TrafficLightSignal
    {
        PEDESTRIAN_WAITING,
        GREEN_TIMEOUT,
        YELLOW_TIMEOUT,
        PED_TIMEOUT,
    }
    public enum COLOR
    {
        BLANK,
        RED,
        YELLOW,
        GREEN
    }
    public class TrafficLight : HSM<TrafficLightSignal, TrafficLightContext>
    {
        public TrafficLight():base()
        {
            SetInitialState(new VehiclesEnabled(new TrafficLightContext { Model = this }));
        }
        COLOR pedColor = COLOR.RED;
        COLOR vehColor = COLOR.RED;
        public void SignalPedestrians(COLOR c)
        {
            pedColor = c;
            Console.WriteLine($"{"Vehicles",-15}{"Pedestrians",15}");
            Console.WriteLine($"  {vehColor.ToString(),-15}{pedColor.ToString(),8}");
            Console.WriteLine("");
        }

        public void SignalVehicles(COLOR c)
        {
            vehColor = c;
            Console.WriteLine($"{"Vehicles",-15}{"Pedestrians",15}");
            Console.WriteLine($"  {vehColor.ToString(),-15}{pedColor.ToString(),8}");
            Console.WriteLine("");
        }

    }
}
