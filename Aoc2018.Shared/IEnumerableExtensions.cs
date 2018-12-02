using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2018.Shared
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> Repeat<TSource>(this IEnumerable<TSource> source)
        {
            var list = source.ToList();
            while (true)
            {
                foreach(var item in list) {
                    yield return item;
                }
            }
        }
        
        public static IEnumerable<TState> Scan<TSource, TState>(this IEnumerable<TSource> input, TState seed, Func<TState, TSource, TState> next)
        {
            var state = seed;
            yield return state;
            foreach(var item in input) {
                state = next(state, item);
                yield return state;
            }
        }
    }
}