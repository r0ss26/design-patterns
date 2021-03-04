using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class AdapterPattern
    {
        public interface IDrone
        {
            void Beep();
            void SpinRotors();
            void TakeOff();
        }

        public interface IDuck
        {
            void Quack();
            void Fly();
        }

        public class SuperDrone : IDrone
        {
            public void Beep()
            {
                Console.WriteLine("Beep beep beep");
            }

            public void SpinRotors()
            {
                Console.WriteLine("Rotors are spinning");
            }

            public void TakeOff()
            {
                Console.WriteLine("Taking Off");
            }
        }

        public class DroneAdapter : IDuck
        {
            private readonly IDrone drone;
            public DroneAdapter(IDrone drone)
            {
                this.drone = drone;
            }

            public void Quack()
            {
                drone.Beep();
            }

            public void Fly()
            {
                drone.TakeOff();
            }
        }

        public class DuckSimulator
        {
            private readonly IDuck duck;
            public DuckSimulator(IDuck duck)
            {
                this.duck = duck;
            }

            public void Run()
            {
                duck.Quack();
                duck.Fly();
            }
        }

        static void Main(string[] args)
        {
            IDrone drone = new SuperDrone();
            IDuck droneAdapter = new DroneAdapter(drone);
            DuckSimulator simulation = new DuckSimulator(droneAdapter);
            simulation.Run();
        }

    }
}
