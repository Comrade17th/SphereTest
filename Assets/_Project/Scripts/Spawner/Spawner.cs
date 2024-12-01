using System;
using UnityEngine;

namespace _Project.Scripts.Spawner
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, ISpawnable<T>
    {
        [SerializeField] private T Prefab;

        [SerializeField] private int startAmount = 1;

        private Pool<T> _pool;
        private int _activeCount = 0;
        private int _spawnsCount = 0;
        
        public event Action<int, int, int> CounterChanged;

        protected virtual void Awake()
        {
            _pool = new Pool<T>(Prefab, transform, transform, startAmount);
        }

        protected virtual void Start()
        {
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);
        }

        public T Spawn()
        {
            T spawnedObject = _pool.Get();

            spawnedObject.Destroying += OnSpawnedDestroy;
            spawnedObject.gameObject.SetActive(true);

            _activeCount++;
            _spawnsCount++;
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);

            return spawnedObject;
        }

        protected void OnSpawnedDestroy(T spawnableObject)
        {
            spawnableObject.Destroying -= OnSpawnedDestroy;
            spawnableObject.gameObject.SetActive(false);
            _pool.Release(spawnableObject);

            _activeCount--;
            CounterChanged?.Invoke(_pool.EntitiesCount, _activeCount, _spawnsCount);
        }
    }

}