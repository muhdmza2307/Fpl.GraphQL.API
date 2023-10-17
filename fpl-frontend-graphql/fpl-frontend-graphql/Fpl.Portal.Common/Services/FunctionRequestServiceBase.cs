using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.Common.Extensions;
using Fpl.Portal.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Common.Services
{
    public abstract class FunctionRequestServiceBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiFunctionOptions _apiFunctionOptions;
        private static JsonSerializerConfigOptions _jsonSerializerConfigOptions = null!;

        protected FunctionRequestServiceBase(IHttpClientFactory httpClientFactory,
            ApiFunctionOptions apiFunctionOptions,
            JsonSerializerConfigOptions jsonSerializerConfigOptions) 
        {
            _httpClientFactory = httpClientFactory;
            _apiFunctionOptions = apiFunctionOptions;
            _jsonSerializerConfigOptions = jsonSerializerConfigOptions;
        }

        public async Task<FunctionRequestResponse<TResponse>> GetAsync<TResponse>(string url)
        {
            try
            {
                var httpClient = GetClient();
                ConfigureClient(httpClient);

                var httpResponseMessage = await httpClient
                    .GetAsync(url)
                    .ConfigureAwait(false);

                var data = await GetDataAsync<TResponse?>(httpResponseMessage).ConfigureAwait(false);
                var errorMessage = GetErrorMessage(httpResponseMessage);

                return new FunctionRequestResponse<TResponse>
                {
                    HttpStatusCode = httpResponseMessage.StatusCode,
                    Data = data,
                    ErrorMessage = errorMessage,
                };
            }
            catch (HttpRequestException httpRequestException)
            {
                throw;
            }
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient();

        protected virtual void ConfigureClient(HttpClient client)
        {
            client.BaseAddress = BaseAddress();
        }

        private Uri BaseAddress() => new(_apiFunctionOptions.ApiBaseUrl);

        private static async Task<TResponse?> GetDataAsync<TResponse>(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                return default;

            return await httpResponseMessage
                .DeserializeAsync<TResponse>(_jsonSerializerConfigOptions)
                .ConfigureAwait(false);
        }

        private static string? GetErrorMessage(HttpResponseMessage httpResponseMessage)
            => !httpResponseMessage.IsSuccessStatusCode 
            ? httpResponseMessage.ReasonPhrase 
            : null;
    }
}
