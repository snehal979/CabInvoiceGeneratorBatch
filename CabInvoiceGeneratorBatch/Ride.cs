using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class Ride
    {
        public double rideDistance;
        public double rideTime;
        /// <summary>
        /// Initialization a new instance of the class
        /// </summary>
        /// <param name="rideDistance"></param>
        /// <param name="rideTime"></param>
        public Ride(double rideDistance, double rideTime)
        {
            this.rideDistance=rideDistance;
            this.rideTime=rideTime;
        }
    }
}
