using Core;
using UnityEngine;
using Zenject;

namespace Ui
{
    [RequireComponent(typeof(Canvas))]
    public class EndgamePopup : MonoBehaviour
    {
        [Inject] private GameCore _gameCore;
        
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _gameCore.EndGame += Show;
        }

        private void OnDestroy()
        {
            _gameCore.EndGame -= Show;
        }

        private void Show()
        {
            _canvas.enabled = true;
        }
    }
}