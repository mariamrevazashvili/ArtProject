using ArtProject.Caching;
using ArtProject.DTOs.Art;
using ArtProject.IServices;
using ArtProject.Models;

namespace ArtProject.Decorator
{
    public class ArtServiceCacheDecorator : IArtService
    {
        private readonly IArtService _art;
        private readonly Cache<object> _cache;

        public ArtServiceCacheDecorator(IArtService art)
        {
            _art = art;
            _cache = Cache<object>.GetInstance();
        }

        private string GetCacheKey(string method, params object[] parameters)
        {
            string key = method;
            foreach (var param in parameters)
            {
                if (param == null)
                {
                    key += ":null";
                }
                else
                {
                    key += ":" + param.ToString();
                }
            }
            return key;
        }

        public async Task<IEnumerable<Art>> GetAllArtsUnderPriceAsync(int price)
        {
            string key = GetCacheKey(nameof(GetAllArtsUnderPriceAsync), price);
            if (_cache.TryGet(key, out object cached))
            {
                return (IEnumerable<Art>)cached;
            }

            var result = await _art.GetAllArtsUnderPriceAsync(price);
            _cache.Set(key, result);
            return result;
        }

        public async Task<IEnumerable<Art>> GetAllArtsAbovePriceAsync(int price)
        {
            string key = GetCacheKey(nameof(GetAllArtsAbovePriceAsync), price);
            if (_cache.TryGet(key, out object cached))
            {
                return (IEnumerable<Art>)cached;
            }

            var result = await _art.GetAllArtsAbovePriceAsync(price);
            _cache.Set(key, result);
            return result;
        }

        public async Task<IEnumerable<Art>> GetArtsByArtistNameAsync(string name)
        {
            string key = GetCacheKey(nameof(GetArtsByArtistNameAsync), name);
            if (_cache.TryGet(key, out object cached))
            {
                return (IEnumerable<Art>)cached;
            }

            var result = await _art.GetArtsByArtistNameAsync(name);
            _cache.Set(key, result);
            return result;
        }

        public async Task<IEnumerable<Art>> GetArtsByLocationAsync(string location)
        {
            string key = GetCacheKey(nameof(GetArtsByLocationAsync), location);
            if (_cache.TryGet(key, out object cached))
            {
                return (IEnumerable<Art>)cached;
            }

            var result = await _art.GetArtsByLocationAsync(location);
            _cache.Set(key, result);
            return result;
        }

        public async Task<double> GetAverageArtPriceAsync()
        {
            string key = GetCacheKey(nameof(GetAverageArtPriceAsync));
            if (_cache.TryGet(key, out object cached))
            {
                return (double)cached;
            }

            var result = await _art.GetAverageArtPriceAsync();
            _cache.Set(key, result);
            return result;
        }

        public void UpdateArt(ArtUpdateDto dto)
        {
            _art.UpdateArt(dto);
            _cache.Clear();
        }

        public async Task<int> CreateartAsync(ArtCreateDto dto)
        {
            int id = await _art.CreateartAsync(dto);
            _cache.Clear();
            return id;
        }

        public async Task<IEnumerable<Art>> GetArtsInPriceRangeAsync(int minPrice, int maxPrice)
        {
            string key = GetCacheKey(nameof(GetArtsInPriceRangeAsync), minPrice, maxPrice);
            if (_cache.TryGet(key, out object cached))
            {
                return (IEnumerable<Art>)cached;
            }

            var result = await _art.GetArtsInPriceRangeAsync(minPrice, maxPrice);
            _cache.Set(key, result);
            return result;
        }
    }

}
