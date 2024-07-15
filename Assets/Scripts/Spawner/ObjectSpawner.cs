using System;
using System.Collections;
using System.Collections.Generic;
using Player.Movement;
using UniRx;
using UnityEngine;
using Zenject;

namespace Spawner
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Transform targetObject;
        [SerializeField] private Platform[] platforms;

        private ObjectPool<Platform> _objectPool;
        private Queue<Platform> _activePlatforms;

        private int _currentZPosition = 0;

        private Platform _prevPlatform;
        private Platform _currentPlatform;

        private void Awake()
        {
            _activePlatforms = new Queue<Platform>();
            Observable.FromMicroCoroutine(InstantiatePlatforms)
                .Subscribe();
        }

        private IEnumerator InstantiatePlatforms()
        {
            var templates = new List<Platform>();

            foreach (var obj in platforms)
            {
                var newObj = Instantiate(obj, new Vector3(0, -100, 0), Quaternion.identity);
                newObj.gameObject.SetActive(false);
                newObj.transform.SetParent(targetObject);
                newObj.PlayerEnterTrigger += () =>
                {
                    Observable.FromMicroCoroutine(_ => SpawnPlatform(false)).Subscribe();
                };
                templates.Add(newObj);
            }
            
            yield return null;
            _objectPool = new ObjectPool<Platform>(templates);
            
            Observable.FromMicroCoroutine(_ => SpawnPlatform(true)).Subscribe();
        }

        private IEnumerator SpawnPlatform(bool isFirst)
        {
            if (_activePlatforms.Count > 2)
            {
                var oldPlatform = _activePlatforms.Dequeue();
                oldPlatform.gameObject.SetActive(false);
                _objectPool.Return(oldPlatform);
            }
            var obj = isFirst? _objectPool.First : _objectPool.Next;

            yield return null;
            
            obj.transform.position = new Vector3(transform.position.x, 0, _currentZPosition);
            _currentZPosition += obj.Size;
            
            obj.gameObject.SetActive(true);
            _activePlatforms.Enqueue(obj);
        }
    }
}
