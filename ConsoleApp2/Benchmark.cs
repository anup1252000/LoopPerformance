
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [MemoryDiagnoser(false)]
    public class Benchmark
    {
        private static readonly Random rng = new(80085);

        [Params(100,100_000,1_000_000)]
        public int Size { get; set; } = 100;

        private List<int> _items;

        [GlobalSetup]
        public void SetUp()
        {
            _items = Enumerable.Range(1, Size).Select(x => rng.Next()).ToList();
        }

        [Benchmark]
        public void For_loop()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
            }
        }

        [Benchmark]
        public void ForEach_loop()
        {
            foreach (var item in _items)
            {

            }
        }

        [Benchmark]
        public void ParallelForEach_loop()
        {
            Parallel.ForEach(_items, x =>
            {

            });
        }

        [Benchmark]
        public void LinqForEach_loop()
        {
            _items.ForEach(x =>
            {

            });
        }

        [Benchmark]
        public void LinParallel_loop()
        {
            _items.AsParallel().ForAll(x =>
            {

            });
        }

        [Benchmark]
        public void ForEachSpan_loop()
        {
            foreach (var item in CollectionsMarshal.AsSpan(_items)) 
            {

            }
        }

        [Benchmark]
        public void ParallelForeachSpan_loop()
        {
            Parallel.ForEach(CollectionsMarshal.AsSpan(_items).ToArray(), x =>
            {

            });
        }
    }
}
