namespace ArtProject.Caching
{
    public class Cache<T>
    {
        private static Cache<T> _instance;
        private Dictionary<string, T> _cache;

        private Cache()
        {
            _cache = new Dictionary<string, T>();
        }

        public static Cache<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Cache<T>();
            }
            return _instance;
        }

        public void Set(string key, T value)
        {
            _cache[key] = value;
        }

        public bool TryGet(string key, out T value)
        {
            return _cache.TryGetValue(key, out value);
        }

        public void Clear()
        {
            _cache.Clear();
        }
    }
}
