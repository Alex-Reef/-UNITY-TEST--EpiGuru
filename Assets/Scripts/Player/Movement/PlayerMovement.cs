using System;
using UniRx;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private int forwardMoveSpeed;
        [SerializeField] private int sidewaysMoveSpeed;
        [SerializeField] private LayerMask gameFieldLayerMask;

        private Camera _camera;
        private Vector3 _targetPosition;
        
        private void Awake()
        {
            Input.multiTouchEnabled = false;
            
            _camera = Camera.main;
            
            #if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
            Observable.EveryUpdate()
                .Where(_ => Input.touchCount > 0)
                .Subscribe(_ => OnTouch(Input.touches[0].position))
                .AddTo(this);
            #else
                Observable.EveryUpdate()
                    .Where(_ => Input.GetMouseButton(0))
                    .Subscribe(_ => OnTouch(Input.mousePosition))
                    .AddTo(this);
            #endif

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    MoveForward();
                    MoveSideways();
                })
                .AddTo(this);
        }

        private void OnTouch(Vector3 screenPosition)
        {
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gameFieldLayerMask))
            {
                Vector3 hitPoint = hit.point;
                UpdateTargetPosition(hitPoint.x);
            }
        }

        private void UpdateTargetPosition(float xPosition)
        {
            _targetPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
        }

        private void MoveSideways()
        {
            float step = sidewaysMoveSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _targetPosition.x, step), transform.position.y, transform.position.z);
        }

        private void MoveForward()
        {
            transform.position += Vector3.forward * forwardMoveSpeed * Time.deltaTime;
        }
    }
}