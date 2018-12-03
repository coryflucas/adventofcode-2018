using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Aoc2018.Day3.Part1
{
    public class Claim
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool OverlapsWith(Claim other)
        {
            return GetPositions()
                .Intersect(other.GetPositions())
                .Any();
        }
        
        public IEnumerable<Position> GetPositions()
        {
            return Enumerable.Range(Left, Width)
                .SelectMany(x =>
                    Enumerable.Range(Top, Height).Select(y => new Position()
                    {
                        Left = x,
                        Top = y,
                    })
                );
        }
        
        private static readonly Regex ClaimDefinitionRegex = new Regex("#(?<id>[0-9]+) @ (?<left>[0-9]+),(?<top>[0-9]+): (?<width>[0-9]+)x(?<height>[0-9]+)");
        public static Claim FromString(string claimDefinition)
        {
            var match = ClaimDefinitionRegex.Match(claimDefinition);
            if (!match.Success)
            {
                throw new ArgumentException($"Invalid claim definition: '{claimDefinition}'", nameof(claimDefinition));
            }

            return new Claim()
            {
                Id = int.Parse(match.Groups["id"].Value),
                Left = int.Parse(match.Groups["left"].Value),
                Top = int.Parse(match.Groups["top"].Value),
                Width = int.Parse(match.Groups["width"].Value),
                Height = int.Parse(match.Groups["height"].Value),
            };
        }
    }
}