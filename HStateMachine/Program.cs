using System;

namespace HStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight trafficLight = new TrafficLight();

            trafficLight.Start();
            Console.WriteLine("\n Press enter for pedestrian signal \n");
            while(Console.ReadLine() == "")
            {
                trafficLight.Handle(TrafficLightSignal.PEDESTRIAN_WAITING);
            }
        }
    }
}
