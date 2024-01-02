namespace TrackMoney.Utils;

internal static class LinqExtension
{

    internal static bool NullOrEmpty<TSource>(this IEnumerable<TSource> source) => source == null || !source.Any();
    internal static bool Empty<TSource>(this IEnumerable<TSource> source) => !source.Any();

}
