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
            Console.WriteLine($"Vehicle light color is {vehColor.ToString()}");
            Console.WriteLine($"Pedestrian light color is {pedColor.ToString()}\n");
        }

        public void SignalVehicles(COLOR c)
        {
            vehColor = c;
            Console.WriteLine($"Vehicle light color is {vehColor.ToString()}");
            Console.WriteLine($"Pedestrian light color is {pedColor.ToString()}\n");
        }

    }
}
