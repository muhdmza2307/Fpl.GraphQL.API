using HotChocolate.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fpl.Portal.Common.Configuration.Options;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Fpl.Portal.Common.Extensions
{
    public static class GenericExtensions
    {
        public static TObject? Deserialize<TObject>(this string @string,
            JsonSerializerConfigOptions jsonSerializerConfigOptions) =>
            JsonSerializer.Deserialize<TObject>(@string, jsonSerializerConfigOptions.Options);
    }
}
