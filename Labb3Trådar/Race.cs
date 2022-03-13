using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labb3Trådar
{
    public class Race
    {
        public List<RacingCar> RacingCars { get; set; }
        public List<RacingCar> FinishList { get; set; }

        public Race()
        {
            RacingCars = new List<RacingCar>();
            FinishList = new List<RacingCar>();
        }
        public void RandomizeProblem(RacingCar rc)
        {
            Random rng = new Random();
            int randomizedNr = rng.Next(1, 51);

            if (randomizedNr == 1)
            {
                Console.WriteLine($"\n{rc.Name} fick slut på bensin och måste tanka i 30 sekunder.");
                Thread.Sleep(30000);
            }
            else if(randomizedNr >1 && randomizedNr <=3)
            {
                Console.WriteLine($"\n{rc.Name} fick punktering och måste byta däck i 20 sekunder.");
                Thread.Sleep(20000);
            }
            else if (randomizedNr>3&&randomizedNr<=8)
            {
                Console.WriteLine($"\n{rc.Name} körde på en fågel och måste tvätta vindrutan i 10 sekunder.");
                Thread.Sleep(10000);
            }
            else if (randomizedNr > 8 && randomizedNr <= 18)
            {
                Console.WriteLine($"\n{rc.Name} fick problem med mototn och kommer därför nu bara kunna köra i {rc.Speed-1} km/h.");
                rc.Speed -= 1;
            }
            else{
                
                //Console.WriteLine("\nIngen olycka för " + rc.Name);
            }
        }

        public void StartRace(RacingCar rc)
        {
            int time = 0;
            while (rc.DistanceDriven < 10000)
            {
                if (time!=0 && (double)time % 300 == 0)
                {
                    RandomizeProblem(rc);
                }
                Thread.Sleep(100);
                time++;
                rc.DistanceDriven += rc.GetSpeedInMS() / 10;

                //Console.WriteLine(rc.Name + " : "+ rc.DistanceDriven );
            }
            FinishList.Add(rc);
            if (FinishList[0].Name == rc.Name)
            {
                Console.WriteLine(rc.Name + " kom i mål och vann!!!");
            }
            else
            {
                int position = FinishList.FindIndex(x => x.Name == rc.Name);
                Console.WriteLine(rc.Name + " kom i mål och slutade på plats " + (position+1) +".");
            }
            
          
            
        }
    }
}
