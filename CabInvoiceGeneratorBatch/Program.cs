namespace CabInvoiceGeneratorBatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Cab Invoice Generator App");
            CabInvoiceGenerator cabInvoiceGenerator = new CabInvoiceGenerator();
            double totalFare = cabInvoiceGenerator.CalculateFare(3.0, 5.0,RideOption.RideType.NORMAL);
            Console.WriteLine(totalFare);
            Console.ReadLine();
        }
    }
}
