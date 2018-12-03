using System;
using System.Linq;
using Aoc2018.Day3.Part1;
using Aoc2018.Shared;

namespace Aoc2018.Day3.Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var claims = StreamUtils.Lines(Console.OpenStandardInput())
                .Select(Claim.FromString)
                .ToList();

            var nonOverLappingClaim = claims.Single(claim => claims
                    .Where(claim2 => claim != claim2)
                    .Select(claim2 => new
                        {
                            Claim1 = claim,
                            Claim2 = claim2,
                        }
                    )
                    .All(x => !x.Claim1.OverlapsWith(x.Claim2))
            );
            Console.WriteLine(nonOverLappingClaim.Id);
        }
    }
}
