using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class CabInvoiceGenerator
    {
        private readonly double cost_Per_KM = 10.0;
        private readonly double cost_Per_Min = 1.0;
        private readonly double min_Fare = 5.0;
        private double cabFare = 0.0;
        /// <summary>
        /// STEP 1 Calculate Fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, double time)
        {
            this.cabFare = (distance * cost_Per_KM)+(time * cost_Per_Min);
            return Math.Max(this.cabFare, min_Fare);
        }
    }
}