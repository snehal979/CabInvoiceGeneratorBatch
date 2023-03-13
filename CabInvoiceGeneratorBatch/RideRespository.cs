using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorBatch
{
    public class RideRespository
    {
        private Dictionary<string, List<Ride>> userRideList = new Dictionary<string, List<Ride>>();

        public void AddCabRides(string userId, Ride[] ride)
        {
            bool checkList = this.userRideList.ContainsKey(userId);
            if (checkList== false)
            {
                this.userRideList.Add(userId, new List<Ride>(ride));
            }
        }
        public Ride[] GetCabRides(string userId)
        {
            return this.userRideList[userId].ToArray();
        }
    }
}
