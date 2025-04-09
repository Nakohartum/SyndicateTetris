using UnityEngine;
using UnityEngine.UI;

namespace SyndicateProject.Game.MainMenu
{
    public class MainMenuView : BasicScreen
    {
        [field: SerializeField] public Button StartGameButton { get; private set; }
        [field: SerializeField] public Button LeaderboardButton { get; private set; }
        [field: SerializeField] public Button ExitGameButton { get; private set; }
    }
}