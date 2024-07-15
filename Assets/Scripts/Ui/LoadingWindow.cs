using System;
using UniRx;
using UnityEngine;

namespace Ui
{
    [RequireComponent(typeof(Canvas))]
    public class LoadingWindow : MonoBehaviour
    {
        private void Awake()
        {
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Subscribe(_ => GetComponent<Canvas>().enabled = false);
        }
    }
}