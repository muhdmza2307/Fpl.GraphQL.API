using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fpl.Portal.Common.Configuration.Options;

public class JsonSerializerConfigOptions
{
    public JsonSerializerOptions Options { get; set; } = new() { PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull  };
}