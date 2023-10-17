using System.Data;
using System.Reflection;
using AutoMapper;
using AutoMapper.Internal;

namespace Fpl.Portal.Common.Extensions;

public static class MappingExtensions
{
    public static TResult MergeInto<TResult>(this IMapper mapper, object item1, object item2) =>
        mapper.Map(item2, mapper.Map<TResult>(item1));

    public static TResult MergeInto<TResult>(this IMapper mapper, params object[] objects)
    {
        // The 'First' object becomes the seed.
        var res = mapper.Map<TResult>(objects.First());
        // We thus skip the first object when we map the remaining objects.
        return objects.Skip(1).Aggregate(res, (dest, src) => mapper.Map(src, dest));
    }
}