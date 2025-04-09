using UnityEngine;
using UnityEngine.UI;

namespace SyndicateProject.Game.MainMenu
{
    public class LeaderboardView : BasicScreen
    {
        [field: SerializeField] public Button BackButton { get; private set; }
        [field: SerializeField] public RectTransform LeaderboardsContainer { get; private set; }
    }
}