using CabInvoiceGeneratorBatch;
namespace CabInvoiceGeneratorAppTest
{
    [TestClass]
    public class UnitTest1
    {
        CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
        Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
        /// <summary>
        /// Step1 - Calculated Fare
        /// </summary>
        [DataRow(3.0,5.0,35.0)] ////Test to get total fare using given time and distance
        [DataRow(0.1, 0.5, 5.0)] // //Test to get Mininum Fare when given less than minimum fare
        [TestMethod]
        public void GivenDistance_Time_ForSingleRide_ShouldReturnTotalFare(double distance,double time, double expectedValue)
        {
            double totalFare = cabInvoiceGenerator.CalculateFare(distance, time,RideOption.RideType.NORMAL);
            Assert.AreEqual(expectedValue, totalFare);
        }
        /// <summary>
        /// (Step2) - Multiple Rides Calculate Total  
        /// </summary>
        [TestMethod]
        public void GivenDistanceAndTimeForMultipleRide_WhenProper_shouldReturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            double invoiceSummary = cabInvoiceGenerator.GetMultipleRideFare(ride, RideOption.RideType.NORMAL);
            Assert.AreEqual(60.0, invoiceSummary);
        }
        /// <summary>
        /// Step 3 -InvoiceSummary For Avergae Fare
        /// </summary>
        [TestMethod]
        public void GivenDistanceAndTimeForMultipleRide_WhenProper_shouldReturnAvergaeFare()
        {
            EnhancedInvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleAverageFare(ride, RideOption.RideType.NORMAL);
            Assert.AreEqual(60.0, invoiceSummary.totalFare);
            Assert.AreEqual(2, invoiceSummary.noOfRide);
        }
        /// <summary>
        /// Step 4 -Test  List of rides by giving userID
        /// </summary>
        [TestMethod]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnAverageFareTotalFare()
        {
            Ride[] ride_New = { new Ride(3.0, 5.0), new Ride(2.0, 5.0),new Ride(4.0,6.0)};
            cabInvoiceGenerator.MapRidesTouse("Snehal", ride); //1st User
            cabInvoiceGenerator.MapRidesTouse("Mayur", ride_New); //2nd User
            EnhancedInvoiceSummary summary = cabInvoiceGenerator.GetInvoiceSummary("Snehal", RideOption.RideType.NORMAL);
            EnhancedInvoiceSummary summary_New = cabInvoiceGenerator.GetInvoiceSummary("Mayur", RideOption.RideType.NORMAL);
            Assert.AreEqual(summary.totalFare, 60.0); //Snehal
            Assert.AreEqual(summary.noOfRide, 2);    //Snehal
            Assert.AreEqual(summary_New.totalFare, 106); //Mayur
            Assert.AreEqual(summary_New.noOfRide, 3);  //Mayur
        }
    }
}