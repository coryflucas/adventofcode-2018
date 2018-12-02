using System.Collections.Generic;
using System.IO;

namespace Aoc2018.Shared
{
    public class StreamUtils
    {
        public static IEnumerable<string> Lines(Stream inputStream)
        {
            using (var sr = new StreamReader(inputStream))
            {
                while (!sr.EndOfStream)
                {
                    yield return sr.ReadLine();
                }
            }
        }    
    }
}