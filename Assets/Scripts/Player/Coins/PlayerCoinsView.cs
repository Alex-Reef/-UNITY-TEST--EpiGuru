using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player.Coins
{
    public class PlayerCoinsView : MonoBehaviour
    {
        [Inject] private PlayerCoinsViewModel _viewModel;
        
        [SerializeField] private TMP_Text coinsText;

        private void Awake()
        {
            _viewModel.Coins
                .Subscribe(coins => coinsText.text = coins.ToString())
                .AddTo(this);
        }
    }
}