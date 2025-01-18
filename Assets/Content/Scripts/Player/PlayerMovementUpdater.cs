using System;
using System.Collections;
using System.Collections.Generic;
using Content.Scripts.Input;
using Content.Scripts.Utilities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem.Controls;

namespace Content.Scripts.Player
{
    public class PlayerMovementUpdater : IUpdater
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        private readonly InputModel _inputModel;
        private Camera _camera;
        public float MaxRayDistance = 1000f;
        private LayerMask _layersToHit;
        private Ray _ray;
        
        public PlayerMovementUpdater(PlayerModel model, PlayerView view, InputModel inputModel)
        {
            _model = model;
            _view = view;
            _inputModel = inputModel;
            _camera = Camera.main;
            _layersToHit = LayerMask.GetMask("Enviroment");
        }

        public void Update(float deltaTime)
        {
            if (!_inputModel.IsLeftCLicked || _inputModel.MouseScreenPosition == Vector2.zero ||
                _inputModel.MouseDelta == Vector2.zero) return;
            _model.CameraRaycastPostion = GetGroundCoordinates();
            Move(_model.CameraRaycastPostion, deltaTime);
            Rotation(_model.CameraRaycastPostion, _view.RotationSpeed, deltaTime);
            
            // Debug.Log(_view.RootRigidbody.velocity);
        }

        private void Move(Vector3 point, float deltaTime)
        {
            // Vector3 k = new Vector3(Mathf.Clamp(_view.RootRigidbody.velocity.x, 0f, _view.MovementSpeed), 0, Mathf.Clamp(_view.RootRigidbody.velocity.z, 0f, _view.MovementSpeed));
            // _view.RootRigidbody.velocity = k;

            _view.Root.position = Vector3.MoveTowards(_view.Root.position, point, _view.MovementSpeed * deltaTime);
        }

        private void Rotation(Vector3 point, float rotationSpeed, float deltaTime)
        {
            Vector3 currentPos = new Vector3(_view.Root.position.x, 0, _view.Root.position.z);
            Vector3 nextPos = new Vector3(point.x, 0, point.z);
            Vector3 newDirecton = Vector3.RotateTowards(_view.Root.forward, nextPos - currentPos,
                rotationSpeed * deltaTime, 0.0f);
            _view.Root.rotation = Quaternion.LookRotation(newDirecton);

            //Debug.DrawRay(new Vector3(_view.Root.position.x, _view.Root.position.y + 1.8f, _view.Root.position.z), newDirecton, Color.red);
        }

        private Vector3 GetGroundCoordinates()
        {
            _ray = _camera.ScreenPointToRay(_inputModel.MouseScreenPosition);
            //Debug.DrawRay(_ray.origin, _ray.direction * MaxRayDistance, Color.white);
            if (Physics.Raycast(_ray, out RaycastHit hit, MaxRayDistance, _layersToHit))
            {
                if (hit.point == _model.CameraRaycastPostion) return _model.CameraRaycastPostion;
                
                return hit.point;
                // Debug.Log(hit.collider.gameObject.layer + "Ray was hit");
                // Debug.Log(hit.point);
            }
            return Vector3.zero;
        }
        
    }
}