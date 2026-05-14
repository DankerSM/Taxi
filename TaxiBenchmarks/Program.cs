using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using TaxiCore;


BenchmarkRunner.Run<TaxiBenchmarks.TaxiBenchmark>();

namespace TaxiBenchmarks
{

    public class TaxiBenchmark
    {
        private List<Driver> _allDrivers;
        private Coordinate _orderPos = new Coordinate(500, 500);
        private NaiveDriverMatcher _naive = new();
        private GridDriverMatcher _grid = new();
        private RadiusDriverMatcher _radius = new();

        [GlobalSetup]
        public void Setup()
        {
            //10000 водителей
            var rand = new Random(42);
            _allDrivers = Enumerable.Range(0, 10000)
                .Select(i => new Driver(i.ToString(), new Coordinate(rand.Next(1000), rand.Next(1000))))
                .ToList();
        }

        [Benchmark]
        
        public List<Driver> NaiveSearch() => _naive.FindClosestDrivers(_orderPos, _allDrivers).ToList();
        [Benchmark]
        public void GridSearch() => _grid.FindClosestDrivers(_orderPos, _allDrivers);

        [Benchmark]
        public void RadiusSearch() => _radius.FindClosestDrivers(_orderPos, _allDrivers);
    }
}
