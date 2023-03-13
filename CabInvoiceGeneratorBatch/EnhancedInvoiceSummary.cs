using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class EnhancedInvoiceSummary
    {
        public double totalFare;
        public double averageFare;
        public int noOfRide;
        public EnhancedInvoiceSummary(double totalFare, int noOfRide)
        {
            this.totalFare=totalFare;
            this.noOfRide=noOfRide;
            //Calculate the AverageFare 
            this.averageFare=this.totalFare/this.noOfRide;
        }
    }
}
