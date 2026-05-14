using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCore
{
    public class GridDriverMatcher : IDriverMatcher
    {
        public IEnumerable<Driver> FindClosestDrivers(Coordinate orderPos, IEnumerable<Driver> allDrivers, int count = 5)
        {
            int cellSize = 10;


            var grid = allDrivers.ToLookup(d => (d.Position.X / cellSize, d.Position.Y / cellSize));

            int orderX = orderPos.X / cellSize;
            int orderY = orderPos.Y / cellSize;

            var candidates = new List<Driver>();
            int radius = 0;

            while (candidates.Count < count && radius < 100)
            {
                for (int x = orderX - radius; x <= orderX + radius; x++)
                {
                    for (int y = orderY - radius; y <= orderY + radius; y++)
                    {

                        if (Math.Abs(x - orderX) == radius || Math.Abs(y - orderY) == radius)
                        {
                            candidates.AddRange(grid[(x, y)]);
                        }
                    }
                }
                radius++;
            }

            return candidates
                .OrderBy(d => GetDist(orderPos, d.Position))
                .Take(count);
        }

        private double GetDist(Coordinate p1, Coordinate p2) =>
            Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));

        //
    }
}
