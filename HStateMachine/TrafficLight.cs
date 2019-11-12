using System;
using System.Collections.Generic;
using System.Text;

namespace HStateMachine
{
    public enum TrafficLightSignal
    {
        PEDESTRIAN_WAITING,
        TIMER_TIMEOUT
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
            
        }
        COLOR pedColor = COLOR.RED;
        COLOR vehColor = COLOR.RED;
        public void SignalPedestrians(COLOR c)
        {
            pedColor = c;
            Console.WriteLine($"Vehicle light color is {vehColor.ToString()}");
            Console.WriteLine($"Pedestrian light color is {pedColor.ToString()}");
        }

        public void SignalVehicles(COLOR c)
        {
            vehColor = c;
            Console.WriteLine($"Vehicle light color is {vehColor.ToString()}");
            Console.WriteLine($"Pedestrian light color is {pedColor.ToString()}");
        }

    }
}
