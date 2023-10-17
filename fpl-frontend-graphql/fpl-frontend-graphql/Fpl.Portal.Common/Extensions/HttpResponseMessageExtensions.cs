using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fpl.Portal.Common.Configuration.Options;

namespace Fpl.Portal.Common.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResult?> DeserializeAsync<TResult>(this HttpResponseMessage httpResponseMessage,
            JsonSerializerConfigOptions jsonSerializerConfigOptions)
        {
            var jsonString = await httpResponseMessage.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            var response = jsonString.Deserialize<TResult>(jsonSerializerConfigOptions);
            return response!;
        }
    }
}
