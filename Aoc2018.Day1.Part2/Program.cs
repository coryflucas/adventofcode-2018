using System;
using System.Collections.Generic;
using System.Linq;
using Aoc2018.Shared;

namespace Aoc2018.Day1.Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var previousSums = new HashSet<int>();
            var result = StreamUtils.Lines(Console.OpenStandardInput())
                .Select(int.Parse)
                .Repeat()
                .Scan(0, (sum, value) => sum + value)
                .Select(sum => new
                {
                    Sum = sum,
                    IsNewValue = previousSums.Add(sum)
                })
                .First(x => !x.IsNewValue);

            Console.WriteLine(result.Sum);
        }
    }
}
