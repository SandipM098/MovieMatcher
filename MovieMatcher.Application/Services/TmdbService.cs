using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieMatcher.Application.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieMatcher.Application.Services
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<TmdbService> _logger;

        public TmdbService(IHttpClientFactory httpClientFactory, IConfiguration config, ILogger<TmdbService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("TmdbClient");
            _apiKey = config["TMDB:ApiKey"] ?? throw new ArgumentNullException("TMDB:ApiKey is not configured");
            _logger = logger;
        }

        public async Task<string?> GetPopularMovieAsync(int page = 1)
        {
            try
            {
                var url = $"movie/popular?api_key={_apiKey}&language=en-US&page={page}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("TMDb /movie/popular failed: {Status} {Reason}", response.StatusCode, response.ReasonPhrase);
                    return null;
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling TMDb GetPopularMovieAsync");
                throw;
            }
        }

        public async Task<string?> SearchMovieAsync(string query, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query))
                return null;

            try
            {
                var encodedQuery = Uri.EscapeDataString(query);
                var url = $"search/movie?api_key={_apiKey}&language=en-US&query={encodedQuery}&page={page}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("TMDb /search/movie failed: {Status} {Reason}", response.StatusCode, response.ReasonPhrase);
                    return null;
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling TMDb SearchMovieAsync");
                throw;
            }
        }
    }
}
