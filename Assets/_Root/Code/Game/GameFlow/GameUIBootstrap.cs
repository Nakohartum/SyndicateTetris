using SyndicateProject.Game.GameFlow.UI;
using UnityEngine;

namespace SyndicateProject.Game.GameFlow
{
    public class GameUIBootstrap : MonoBehaviour
    {
        [SerializeField] private NextItemView _nextItemView;
        public GameUIPresenter Presenter;

        public void CreateUI()
        {
            Presenter = new GameUIPresenter(_nextItemView);
        }
    }
}