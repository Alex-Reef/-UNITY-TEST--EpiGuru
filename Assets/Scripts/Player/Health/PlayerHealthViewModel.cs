using UniRx;
using Zenject;

namespace Player.Health
{
    public class PlayerHealthViewModel
    {
        private readonly PlayerHealthModel _model;

        public ReactiveProperty<int> Health;

        [Inject]
        public PlayerHealthViewModel(PlayerCollision playerCollision)
        {
            _model = new PlayerHealthModel();
            Health = new ReactiveProperty<int>(_model.Health);
            
            playerCollision.DamageReceived += () => Health.Value--;
        }
    }
}