using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3Trådar
{
    public class RacingCar
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public double DistanceDriven { get; set; }
        public double GetSpeedInMS()
        {
            return Speed / 3.6;
        }
    }
}
