using System;
using System.Collections;
using System.Net;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Content.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        public Animator PlayerAnimator;
        public float MovementSpeed = 0.1f;
        public float RotationSpeed = 40f;
        public Transform Root;
        public Rigidbody RootRigidbody;
    }
}
