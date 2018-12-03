using System;
using System.Linq;
using Aoc2018.Shared;

namespace Aoc2018.Day3.Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var overLappingPositionsCount = StreamUtils.Lines(Console.OpenStandardInput())
                .Select(Claim.FromString)
                .SelectMany(claim => claim.GetPositions())
                .GroupBy(p => p)
                .Count(p => p.Count() > 1);
            
            Console.WriteLine(overLappingPositionsCount);
        }
    }
}
