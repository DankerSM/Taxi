using TaxiCore;

namespace TaxiTest
{
    public class Tests 
    {
        [Test]
        public void NaiveMatcher_ShouldReturnClosestDrivers()
        {
            var matcher = new NaiveDriverMatcher();
            var orderPos = new Coordinate(0, 0);
            var drivers = new List<Driver>
        {
            new Driver("Far", new Coordinate(10, 10)),
            new Driver("Close", new Coordinate(1, 1)),
            new Driver("Medium", new Coordinate(5, 5)),
            new Driver("VeryClose", new Coordinate(0, 1)),
            new Driver("SuperFar", new Coordinate(100, 100)),
            new Driver("Near", new Coordinate(2, 2))
        };


            var result = matcher.FindClosestDrivers(orderPos, drivers, 5).ToList();

            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("VeryClose", result[0].Id);
        }
    }
}
