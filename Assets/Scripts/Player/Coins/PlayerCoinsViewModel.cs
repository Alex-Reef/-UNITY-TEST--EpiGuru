using UniRx;
using Zenject;

namespace Player.Coins
{
    public class PlayerCoinsViewModel
    {
        private readonly PlayerCoinsModel _model;

        public ReactiveProperty<int> Coins;

        [Inject]
        public PlayerCoinsViewModel(PlayerCollision playerCollision)
        {
            _model = new PlayerCoinsModel();
            Coins = new ReactiveProperty<int>(_model.Coins);
            
            playerCollision.CoinReceived += () => Coins.Value++;
        }
    }
}