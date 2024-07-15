using UnityEngine;
using Zenject;

namespace Player.Installers
{
    public class PlayerCollisionInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCollision playerCollision;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerCollision>().FromInstance(playerCollision).AsSingle().NonLazy();
        }
    }
}