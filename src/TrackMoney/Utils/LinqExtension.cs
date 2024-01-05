namespace TrackMoney.Utils;

internal static class LinqExtension
{

    internal static bool NullOrEmpty<TSource>(this IEnumerable<TSource> source) => source == null || !source.Any();
    internal static bool Empty<TSource>(this IEnumerable<TSource> source) => !source.Any();
    internal static bool NotContains<TSource>(this IEnumerable<TSource> source, TSource item) => !source.Contains(item);
    internal static bool NotAny<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) => !source.Any(predicate);
}
