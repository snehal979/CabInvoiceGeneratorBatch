using CabInvoiceGeneratorBatch;
namespace CabInvoiceGeneratorAppTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Step1 - Calculated Fare
        /// </summary>
        [DataRow(3.0,5.0,35.0)] ////Test to get total fare using given time and distance
        [DataRow(0.1, 0.5, 5.0)] // //Test to get Mininum Fare when given less than minimum fare
        [TestMethod]
        public void GivenDistance_Time_ForSingleRide_ShouldReturnTotalFare(double distance,double time, double expectedValue)
        {
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            double totalFare = cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(expectedValue, totalFare);
        }
    }
}