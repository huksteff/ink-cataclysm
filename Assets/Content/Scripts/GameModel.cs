using Content.Scripts.Input;
using Content.Scripts.Player;
using Content.Scripts.Utilities;
using UnityEngine;

namespace Content.Scripts
{
    public class GameModel
    {
        public InputModel InputModel { get; }
        public PlayerModel PlayerModel { get; }
        public UpdatersList UpdatersList { get; }

        public GameModel(InputModel inputModel, PlayerModel playerModel, UpdatersList updatersList)
        {
            InputModel = inputModel;
            PlayerModel = playerModel;
            UpdatersList = updatersList;
        }
    }
}