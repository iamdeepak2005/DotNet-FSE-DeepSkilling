using System;
using NUnit.Framework;
using Moq;

namespace Training.Week3.MoqTesting
{
    // interface representing external service dependency
    public interface IDollarToEuroExchangeRateFeed
    {
        double GetRate();
    }

    // domain class using dependency injection
    public class DollarConverter
    {
        private readonly IDollarToEuroExchangeRateFeed _feed;

        public DollarConverter(IDollarToEuroExchangeRateFeed feed)
        {
            _feed = feed;
        }

        public double ConvertToEuro(double amountInUsd)
        {
            double rate = _feed.GetRate(); // fetch rate from external dependency
            return amountInUsd * rate;
        }
    }

    [TestFixture]
    public class DollarConverterTests
    {
        [Test]
        public void ConvertToEuro_UsingMockFeed_CalculatesCorrectValue()
        {
            // create mock object for our feed interface
            var mockFeed = new Mock<IDollarToEuroExchangeRateFeed>();
            
            // set up mock output behavior when GetRate is called
            mockFeed.Setup(f => f.GetRate()).Returns(0.92);

            // inject mock into constructor (Dependency Injection testing)
            var converter = new DollarConverter(mockFeed.Object);

            double euros = converter.ConvertToEuro(100.00);

            // Assert
            Assert.AreEqual(92.00, euros, 0.001);

            // Verify that the mock dependency method GetRate() was called exactly once
            mockFeed.Verify(f => f.GetRate(), Times.Once);
        }
    }
}