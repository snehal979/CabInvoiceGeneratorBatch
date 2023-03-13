using CabInvoiceGeneratorBatch;
namespace CabInvoiceGeneratorAppTest
{
    [TestClass]
    public class UnitTest1
    {
        CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
        /// <summary>
        /// Step1 - Calculated Fare
        /// </summary>
        [DataRow(3.0,5.0,35.0)] ////Test to get total fare using given time and distance
        [DataRow(0.1, 0.5, 5.0)] // //Test to get Mininum Fare when given less than minimum fare
        [TestMethod]
        public void GivenDistance_Time_ForSingleRide_ShouldReturnTotalFare(double distance,double time, double expectedValue)
        {
            double totalFare = cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(expectedValue, totalFare);
        }
        /// <summary>
        /// (Step2) - Multiple Rides Calculate Total  
        /// </summary>
        [TestMethod]
        public void GivenDistanceAndTimeForMultipleRide_WhenProper_shouldReturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            double invoiceSummary = cabInvoiceGenerator.GetMultipleRideFare(ride);
            Assert.AreEqual(60.0, invoiceSummary);
        }
    }
}