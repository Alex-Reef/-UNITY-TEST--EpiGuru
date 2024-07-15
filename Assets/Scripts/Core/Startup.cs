using Gpm.WebView;
using UnityEngine;
using Utils;
using Zenject;

namespace Core
{
    public class Startup : MonoBehaviour
    {
        [Inject] private LocationController _locationController;
        [SerializeField] private Canvas mainUiCanvas;
        [SerializeField] private Canvas loadingCanvas;
        [SerializeField] private Canvas noAllowedLocationCanvas;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            loadingCanvas.enabled = true;
            _locationController.LocationAllowed += OnLocationChecked;
            _locationController.Check();
        }

        private void OnDestroy()
        {
            _locationController.LocationAllowed -= OnLocationChecked;
        }

        private void OnLocationChecked(bool locationAllowed)
        {
            mainUiCanvas.enabled = locationAllowed;
            if (!locationAllowed)
            {
                GpmWebView.ShowUrl(
                    "https://uk.wikipedia.org/",
                    new GpmWebViewRequest.Configuration()
                    {
                        style = GpmWebViewStyle.FULLSCREEN,
                        orientation = GpmOrientation.UNSPECIFIED,
                        isClearCookie = true,
                        isClearCache = true,
                        backgroundColor = "#FFFFFF",
                        isNavigationBarVisible = true,
                        navigationBarColor = "#4B96E6",
                        title = "No allowed location",
                        isBackButtonVisible = true,
                        isForwardButtonVisible = true,
                        isCloseButtonVisible = true,
                        supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE
#endif
                    },null, null);
            }
            
            noAllowedLocationCanvas.enabled = !locationAllowed;
            loadingCanvas.enabled = false;
        }
    }
}