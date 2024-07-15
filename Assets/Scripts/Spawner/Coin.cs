using UnityEngine;

namespace Spawner
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private Platform currentPlatform;

        private void Awake()
        {
            currentPlatform.PlayerEnterTrigger += () => gameObject.SetActive(true);
        }
    }
}