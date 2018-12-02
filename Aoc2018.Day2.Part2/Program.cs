using System;
using System.Linq;
using Aoc2018.Shared;

namespace Aoc2018.Day2.Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = StreamUtils.Lines(Console.OpenStandardInput()).ToList();
            var veryClose = input.SelectMany((lines1, pos) => input
                    .Skip(pos)
                    .Select(lines2 => new
                        {
                            Lines1 = lines1,
                            Lines2 = lines2,
                        }
                    )
                )
                .Select(lines =>
                {
                    var zippedChars = lines.Lines1.Zip(lines.Lines2,
                        (c1, c2) => new {Char1 = c1, Char2 = c2})
                        .ToList();
                    return new
                    {
                        MatchingChars = zippedChars.Where(x => x.Char1 == x.Char2).Select(x => x.Char1),
                        MisMatchCount = zippedChars.Count(x => x.Char1 != x.Char2)
                    };
                })
                .Single(x => x.MisMatchCount == 1);
            
            Console.WriteLine(new string(veryClose.MatchingChars.ToArray()));
        }
    }
}
