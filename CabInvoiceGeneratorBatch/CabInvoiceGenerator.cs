using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class CabInvoiceGenerator
    {
        RideRespository rideRespository = new RideRespository();
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
            // becuase the min fare is 5 means we get cabfare is 4 then it will be minimum fare is constant(5)
        }
        /// <summary>
        ///  (step 2) Multiple Ride
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public double GetMultipleRideFare(Ride[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += CalculateFare(ride.rideDistance, ride.rideTime);
            }
            return totalRideFare;
        }
        /// <summary>
        /// EnhancedInvoiceSummary Avergae fare (step 3)
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public EnhancedInvoiceSummary GetMultipleAverageFare(Ride[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += CalculateFare(ride.rideDistance, ride.rideTime);
            }
            return new EnhancedInvoiceSummary(totalRideFare, rides.Length);
        }
        /// <summary>
        /// Step 4 Given userId And RideRespositories Return Invoice 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void MapRidesTouse(string userId, Ride[] rides)
        {
            rideRespository.AddCabRides(userId, rides);
        }
        public EnhancedInvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.GetMultipleAverageFare(this.rideRespository.GetCabRides(userId));
        }
    }
}