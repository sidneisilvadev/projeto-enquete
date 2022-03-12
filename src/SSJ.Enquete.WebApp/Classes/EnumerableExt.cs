using System;
using System.Collections.Generic;
using System.Linq;

namespace SSJ.Enquete.WebApp.Classes
{
	public static class EnumerableExt
	{
		public static TSource FirstWithMax<TSource, TSelector>(this IEnumerable<TSource> source, Func<TSource, TSelector> selector)
		{
			if (!source.Any())
				return default;

			var max = source.Max(selector);
			return source.FirstOrDefault(i => selector(i).Equals(max));
		}

		public static IEnumerable<TSource> AllWithMax<TSource, TSelector>(this IEnumerable<TSource> source, Func<TSource, TSelector> selector)
		{
			if (!source.Any())
				return Enumerable.Empty<TSource>();

			var max = source.Max(selector);
			return source.Where(i => selector(i).Equals(max)).ToArray();
		}

		public static IEnumerable<TSource> AllWithMin<TSource, TSelector>(this IEnumerable<TSource> source, Func<TSource, TSelector> selector)
		{
			if (!source.Any())
				return Enumerable.Empty<TSource>();

			var max = source.Min(selector);
			return source.Where(i => selector(i).Equals(max)).ToArray();
		}
	}
}