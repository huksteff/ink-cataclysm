using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Content.Scripts.Input
{
    public class InputView : MonoBehaviour
    {
        public event Action<Vector2> OnMouseMove; 
        public event Action<bool> OnLeftClick; 
        public event Action<Vector2> OnMouseDelta; 
        
        public InputActionAsset PlayerInputAsset;
        
        public void Initializa()
        {
            PlayerInputAsset.Enable();

            PlayerInputAsset["Mouse"].performed += OnMouseMoveInput;
            PlayerInputAsset["LeftClick"].performed += OnMouseClick;
            PlayerInputAsset["LeftClick"].canceled += OnMouseCanceled;
            PlayerInputAsset["MouseDelta"].performed += OnMouseDeltaPerformed;
        }

        public void Dispose()
        {
            PlayerInputAsset.Disable();

            PlayerInputAsset["Mouse"].performed -= OnMouseMoveInput;
            PlayerInputAsset["LeftClick"].performed -= OnMouseClick;
            PlayerInputAsset["LeftClick"].canceled -= OnMouseCanceled;
            PlayerInputAsset["MouseDelta"].performed -= OnMouseDeltaPerformed;
        }

        private void OnMouseMoveInput(InputAction.CallbackContext ctx)
        {
            OnMouseMove?.Invoke(ctx.ReadValue<Vector2>());
        }

        private void OnMouseDeltaPerformed(InputAction.CallbackContext ctx)
        {
            OnMouseDelta?.Invoke(ctx.ReadValue<Vector2>());
        }

        private void OnMouseClick(InputAction.CallbackContext ctx)
        {
            OnLeftClick?.Invoke(true);
        }

        private void OnMouseCanceled(InputAction.CallbackContext ctx)
        {
            OnLeftClick?.Invoke(false);
        }
    }
}