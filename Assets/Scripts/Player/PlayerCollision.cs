using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerCollision : MonoBehaviour
    {
        public event Action CoinReceived;
        public event Action DamageReceived;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.tag.Equals("coin", StringComparison.OrdinalIgnoreCase)) return;
            
            CoinReceived?.Invoke();
            other.gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag.Equals("props", StringComparison.OrdinalIgnoreCase))
                DamageReceived?.Invoke();
        }
    }
}