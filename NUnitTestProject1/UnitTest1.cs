using CabInvoiceGenerator;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedSummary, summary);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnEnhancedInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedSummary.averageFare, summary.averageFare);
            Assert.AreEqual(expectedSummary.numberOfRides, summary.numberOfRides);
            Assert.AreEqual(expectedSummary.totalFare, summary.totalFare);
        }

        [Test]
        public void GivenAUserIDTheInvoiceServiceGetsTheListOfRidesFromTheRideRepositoryAndReturnsTheInvoice()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("FerrariKiSawari", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("FerrariKiSawari");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30);
            Assert.AreEqual(expectedSummary, summary);
        }

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPremiumRide()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
    }
}