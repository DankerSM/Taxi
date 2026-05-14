using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCore
{
    public class RadiusDriverMatcher : IDriverMatcher
    {
        public IEnumerable<Driver> FindClosestDrivers(Coordinate orderPos, IEnumerable<Driver> allDrivers, int count = 5)
        {
            int initialRadius = 50;

            var candidates = allDrivers
                .Where(d => Math.Abs(d.Position.X - orderPos.X) <= initialRadius &&
                            Math.Abs(d.Position.Y - orderPos.Y) <= initialRadius)
                .ToList();

            if (candidates.Count < count)
            {
                candidates = allDrivers.ToList();
            }

            return candidates
                .OrderBy(d => GetDistance(orderPos, d.Position))
                .Take(count);
        }

        private double GetDistance(Coordinate p1, Coordinate p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
