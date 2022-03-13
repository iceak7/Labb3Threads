using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Labb3Trådar
{
    class Program
    {
        static void Main(string[] args)
        {
            Race rac1 = new Race();
            RacingCar car1 = new RacingCar { DistanceDriven = 0, Name = "Bil 1", Speed = 120 };
            RacingCar car2 = new RacingCar { DistanceDriven = 0, Name = "Bil 2", Speed = 120 };

            List<RacingCar> rcList = new List<RacingCar>();

            Task task1 = Task.Run(() =>
            {
                rac1.StartRace(car1);

            });
            Task task2 = Task.Run(() =>
            {
                rac1.StartRace(car2);

            });
            rac1.RacingCars.Add(car1);
            rac1.RacingCars.Add(car2);

            bool contin = true;
            while (contin)
            {
                string input = Console.ReadLine();

                if (input.ToUpper() == "STATUS")
                {

                    Console.WriteLine("\nStatusuppdatering för de " + rac1.RacingCars.Count+ " tävlande.");
                    foreach (var item in rac1.RacingCars)
                    {                      
                        Console.WriteLine($"\n{item.Name}\n" +
                            $"Distans körd: { item.DistanceDriven.ToString("F1")} meter\n" +
                            $"Hastighet: {item.Speed} km/h");
                    }
                }
                else if (input.ToUpper() == "AVBRYT")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
