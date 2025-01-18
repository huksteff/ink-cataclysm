using Content.Scripts.Utilities;
using UnityEngine;
using UnityEngine.XR;

namespace Content.Scripts.Input
{
    public class InputPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly InputModel _model;
        private readonly InputView _view;

        public InputPresenter(GameModel gameModel, InputModel inputModel, InputView inputView)
        {
            _gameModel = gameModel;
            _model = inputModel;
            _view = inputView;
        }
        
        public void Init()
        {
            _view.Initializa();
            
            _view.OnMouseMove += HandleMouseMove;
            _view.OnLeftClick += HandleLeftClick;
            _view.OnMouseDelta += HandleMouseDelta;
        }

        public void Dispose()
        {
            _view.Dispose();

            _view.OnMouseMove -= HandleMouseMove;
            _view.OnLeftClick -= HandleLeftClick;
            _view.OnMouseDelta -= HandleMouseDelta;
        }

        private void HandleLeftClick(bool state)
        {
            _model.IsLeftCLicked = state;
        }

        private void HandleMouseMove(Vector2 vector)
        {
            if (!_model.IsLeftCLicked) return;
            _model.MouseScreenPosition = vector;
        }

        private void HandleMouseDelta(Vector2 vector)
        {
            _model.MouseDelta = vector;
        }
    }
}