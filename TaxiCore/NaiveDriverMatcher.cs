using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCore
{
    public class NaiveDriverMatcher : IDriverMatcher
    {
        public IEnumerable<Driver> FindClosestDrivers(Coordinate orderPos, IEnumerable<Driver> allDrivers, int count = 5)
        {
            return allDrivers
                .Select(driver => new
                {
                    Driver = driver,
                    Distance = CalculateDistance(orderPos, driver.Position)
                })
                .OrderBy(x => x.Distance)
                .Take(count)
                .Select(x => x.Driver);
        }

        private double CalculateDistance(Coordinate p1, Coordinate p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
