using System;
using Player.Health;
using Spawner;
using Ui;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameCore : MonoBehaviour
    {
        [Inject] private PlayerHealthViewModel _healthViewModel;
        
        public event Action EndGame;
        
        private void Awake()
        {
            _healthViewModel.Health
                .Where(health => health == 0)
                .Subscribe(_ =>
                {
                    SetPause(true);
                    EndGame?.Invoke();
                })
                .AddTo(this);
            
            SetPause(false);
        }
        
        public void SetPause(bool pause)
        {
            Time.timeScale = pause? 0 : 1;
        }
    }
}