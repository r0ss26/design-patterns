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
            void Update(int temparature, int windSpeed, int pressure);
        }
        public class WeatherStation : ISubject
        {
            private int temperature;
            public int WindSpeed { get; set;  }
            private int pressure;
            private List<IObserver> observers;
            public WeatherStation(int temperature, int windSpeed, int pressure)
            {
                this.temperature = temperature;
                this.WindSpeed = windSpeed;
                this.pressure = pressure;
                this.observers = new List<IObserver>();
            }

            public int Temperature
            {
                get
                {
                    return this.temperature;
                }
                set
                {
                    this.temperature = value;
                }
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
                    observer.Update(this.temperature, this.WindSpeed, this.pressure);
                }
            }
        }

        public class UserInterface : IObserver
        {
            public void Update(int t, int w, int p)
            {
                Console.WriteLine("User Interface - Temparature (" + t + ") Windspeed (" + w + ") Pressure (" + p + ")");
            }
        }

        public class Logger : IObserver
        {
            public void Update(int t, int w, int p)
            {
                Console.WriteLine("Log - Temparature (" + t + ") Windspeed (" + w + ") Pressure (" + p + ")");
            }
        }

        public class AlertSystem : IObserver
        {
            public void Update(int t, int w, int p)
            {
                Console.WriteLine("Alert System - Temparature (" + t + ") Windspeed (" + w + ") Pressure (" + p + ")");
            }
        }
        static void Main(String[] args)
        {
            var weatherStation = new WeatherStation(1, 2, 3);
            var ui = new UserInterface();
            var log = new Logger();
            var alert = new AlertSystem();
            weatherStation.RegisterObserver(ui);
            weatherStation.RegisterObserver(log);
            weatherStation.RegisterObserver(alert);
            weatherStation.Temperature = 100;
            weatherStation.NotifyObservers();
            weatherStation.Temperature = 50;
            weatherStation.NotifyObservers();
            weatherStation.WindSpeed = 60;
            weatherStation.NotifyObservers();
            Console.ReadLine();
        }
    }
}
