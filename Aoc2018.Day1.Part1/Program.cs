using System;
using System.Linq;
using Aoc2018.Shared;

namespace Aoc2018.Day1.Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result = StreamUtils.Lines(Console.OpenStandardInput())
                .Select(int.Parse)
                .Sum();
            Console.WriteLine(result);
        }
    }
}
