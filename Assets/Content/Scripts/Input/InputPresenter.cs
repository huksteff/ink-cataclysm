using Content.Scripts.Utilities;
using UnityEngine;

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
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}