using System;
using OneSignalSDK;
using UnityEngine;

namespace Utils
{
    public class SdkInitializer : MonoBehaviour
    {
        [SerializeField] private string oneSignalAppId;
        
        private void Awake()
        {
            if (string.IsNullOrEmpty(oneSignalAppId))
            {
                throw new NullReferenceException("One Signal App Id is null");
            }
            OneSignal.Initialize(oneSignalAppId);
        }
    }
}
