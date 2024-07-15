using Player.Coins;
using Zenject;

namespace Player.Installers
{
    public class PlayerCoinsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerCoinsViewModel>().FromNew().AsSingle().NonLazy();
        }
    }
}