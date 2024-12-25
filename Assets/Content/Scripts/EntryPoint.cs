using System;
using Content.Scripts.Input;
using Content.Scripts.Player;
using Content.Scripts.Utilities;
using UnityEngine;

namespace Content.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        public InputView InputView;
        public PlayerView PlayerView;
        private GameModel _gameModel;
        private readonly PresentersList _presentersList = new();
        private readonly UpdatersList _updatersList = new();

        private void Start()
        {
            _gameModel = new GameModel(new InputModel(), new PlayerModel(), _updatersList);
            _presentersList.Add(new InputPresenter(_gameModel, _gameModel.InputModel, InputView));
            _presentersList.Add(new PlayerPresenter(_gameModel, _gameModel.PlayerModel, PlayerView));
            
            _presentersList.Init();
        }

        private void Update()
        {
            _updatersList.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _presentersList.Dispose();
            _presentersList.Clear();
        }
    }
}