using System;
using System.Linq;
using Aoc2018.Shared;

namespace Aoc2018.Day2.Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var counts = StreamUtils.Lines(Console.OpenStandardInput())
                .Select(line =>
                {
                    var charGroups = line.GroupBy(x => x);
                    return new
                    {
                        ContainsChar2x = charGroups.Any(x => x.Count() == 2),
                        ContainsChar3x = charGroups.Any(x => x.Count() == 3),
                    };
                })
                .Aggregate(new
                    {
                        Count2x = 0,
                        Count3x = 0,
                    },
                    (acc, value) => new
                    {
                        Count2x = acc.Count2x + (value.ContainsChar2x ? 1 : 0),
                        Count3x = acc.Count3x + (value.ContainsChar3x ? 1 : 0),
                    });
            Console.WriteLine(counts.Count2x * counts.Count3x);
        }
    }
}
