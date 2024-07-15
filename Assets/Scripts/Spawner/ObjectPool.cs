using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class ObjectPool<T>
    {
        private List<T> _pool;

        public T First
        {
            get
            {
                if (_pool.Count == 0)
                    return default;
                var obj = _pool[0];
                _pool.RemoveAt(0);
                return obj;
            }
        }

        public T Next
        {
            get
            {
                if (_pool.Count == 0)
                    return default;
                var id = Random.Range(0, _pool.Count);
                var obj = _pool[id];
                _pool.RemoveAt(id);
                return obj;
            }
        }
        
        public void Return(T value) => _pool.Add(value);
        
        public ObjectPool(List<T> objects)
        {
            _pool = new List<T>(objects);
        }
    }
}