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
        private IUpdater _updater;
        private readonly PresentersList _presentersList = new PresentersList();

        public PlayerPresenter(GameModel gameModel, PlayerModel model, PlayerView view)
        {
            _gameModel = gameModel;
            _playerView = view;
            _playerModel = model;
        }

        public void Init()
        {
            _presentersList.Init();

            _updater = new PlayerMovementUpdater(_playerModel, _playerView, _gameModel.InputModel);
            _gameModel.FixedUpdatersList.Add(_updater);
        }

        public void Dispose()
        {
            _gameModel.FixedUpdatersList.Add(_updater);
        }
    }
}
