using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class GameCoreInstaller : MonoInstaller
    {
        [SerializeField] private GameCore gameCore;
        
        public override void InstallBindings()
        {
            Container.Bind<GameCore>().FromInstance(gameCore).AsSingle().NonLazy();
        }
    }
}