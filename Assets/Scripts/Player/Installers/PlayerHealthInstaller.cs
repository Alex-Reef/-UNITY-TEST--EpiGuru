using Player.Health;
using Zenject;

namespace Player.Installers
{
    public class PlayerHealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerHealthViewModel>().FromNew().AsSingle().NonLazy();
        }
    }
}