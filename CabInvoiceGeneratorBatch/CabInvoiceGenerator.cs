using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class CabInvoiceGenerator : RideOption
    {
        RideRespository rideRespository = new RideRespository();
        RideOption rideOption = new RideOption();
        private double cabFare = 0.0;
        /// <summary>
        /// STEP 1 Calculate Fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, double time , RideType rideType) //pass enum
        {
            // call that method for the selection of ridetype and retuen value
            RideOption option = rideOption.SetRideValue(rideType);
            cabFare = (distance * option.cost_Per_KM)+(time * option.cost_Per_Mint);

            return Math.Max(this.cabFare, option.min_Fare);
            // becuase the min fare is 5 means we get cabfare is 4 then it will be minimum fare is constant(5)
        }
        /// <summary>
        ///  (step 2) Multiple Ride
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public double GetMultipleRideFare(Ride[] rides,RideType rideType)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += CalculateFare(ride.rideDistance, ride.rideTime,rideType);
            }
            return totalRideFare;
        }
        /// <summary>
        /// EnhancedInvoiceSummary Avergae fare (step 3)
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public EnhancedInvoiceSummary GetMultipleAverageFare(Ride[] rides,RideType rideType)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += CalculateFare(ride.rideDistance, ride.rideTime,rideType);
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
        public EnhancedInvoiceSummary GetInvoiceSummary(string userId,RideType rideType)
        {
            return this.GetMultipleAverageFare(this.rideRespository.GetCabRides(userId),rideType);
        }
    }
}