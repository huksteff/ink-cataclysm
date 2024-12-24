using Content.Scripts.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Content.Scripts.Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly PlayerView _playerView;
        private readonly PlayerModel _playerModel;

        public PlayerPresenter(GameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _playerView = view;
            _playerModel = model;
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
