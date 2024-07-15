using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player.Health
{
    public class PlayerHealthView : MonoBehaviour
    {
        [Inject] private PlayerHealthViewModel _viewModel;
        
        [SerializeField] private TMP_Text healthText;

        private void Awake()
        {
            _viewModel.Health
                .Subscribe(health => healthText.text = health.ToString())
                .AddTo(this);
        }
    }
}