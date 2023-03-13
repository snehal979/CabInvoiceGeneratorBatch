using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class RideOption
    {
        /// <summary>
        /// Step 5 -Primeum Ride
        /// </summary>
        public enum RideType
        {
            NORMAL,
            PREMILM,
        }
        public double cost_Per_KM;
        public double cost_Per_Mint;
        public double min_Fare;
        public RideOption(double cost_Per_Kilo, double cost_Per_Min, double minimum_Fare)
        {
            cost_Per_KM = cost_Per_Kilo;
            cost_Per_Mint = cost_Per_Min;
            min_Fare = minimum_Fare;
        }
        public RideOption()
        {

        }
        public RideOption SetRideValue(RideType rideType)
        {
            switch (rideType)
            {
                case RideType.NORMAL:
                    return new RideOption(10.0, 1.0, 5.0); //Pass Constructor
                case RideType.PREMILM:
                    return new RideOption(15.0, 2.0, 20.0);
                default:
                    return null;
            }
        }
    }
}
