using System;
using UnityEngine;

namespace Spawner
{
    [RequireComponent(typeof(BoxCollider))]
    public class Platform : MonoBehaviour
    {
        public event Action PlayerEnterTrigger;

        private int _zSize = 0;

        public int Size => _zSize;

        private void Awake()
        {
            _zSize = (int)GetComponent<BoxCollider>().size.z;
        }

        private void OnTriggerEnter(Collider other)
        {
            PlayerEnterTrigger?.Invoke();
        }
    }
}