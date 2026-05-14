using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCore
{
    public interface IDriverMatcher
    {
        IEnumerable<Driver> FindClosestDrivers(Coordinate orderPos, IEnumerable<Driver> allDrivers, int count = 5);
    }
}
