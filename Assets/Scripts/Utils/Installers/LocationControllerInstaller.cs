using UnityEngine;
using Zenject;

namespace Utils.Installers
{
    public class LocationControllerInstaller : MonoInstaller
    {
        [SerializeField] private LocationController locationController;
    
        public override void InstallBindings()
        {
            Container.Bind<LocationController>().FromInstance(locationController).AsSingle().NonLazy();
        }
    }
}