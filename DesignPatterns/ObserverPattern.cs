using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class ObserverPattern
    {
        public interface ISubject
        {
            void RegisterObserver(IObserver observer);
            void RemoveObserver(IObserver observer);
            void NotifyObservers();

        }
        public interface IObserver
        {
            void Update();
        }
        public class WeatherStation : ISubject
        {
            private int temperature;
            private int windSpeed;
            private int pressure;
            private List<IObserver> observers;
            public WeatherStation(int temperature, int windSpeed, int pressure)
            {
                this.temperature = temperature;
                this.windSpeed = windSpeed;
                this.pressure = pressure;
            }

            public void RegisterObserver(IObserver observer)
            {
                this.observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer)
            {
                this.observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                foreach (IObserver observer in this.observers)
                {
                    observer.Update(this.windSpeed, this.temperature, this.pressure);
                }
            }
        }

        public class UserInterface : IObserver
        {
            void Display()
            {
                Console.WriteLine("");
            }

            public void Update()
            {

            }
        }

        public class Logger : IObserver
        {
            void Log()
            {
                Console.WriteLine("");
            }

            public void Update()
            {

            }
        }

        public class AlertSystem : IObserver
        {
            void Alert()
            {
                Console.WriteLine("");
            }

            public void Update()
            {

            }
        }
    }
}
