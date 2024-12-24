using System;
using UnityEngine;

namespace Content.Scripts.Player
{
    public class PlayerModel
    {
        public event Action OnMove;

        private Vector3 _playerPosition;

        public PlayerModel()
        {
            
        }

        public void OnTransformPositon()
        {
            Debug.Log(_playerPosition);
        }
    }
}
