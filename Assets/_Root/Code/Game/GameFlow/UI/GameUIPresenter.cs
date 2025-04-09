using UnityEngine;

namespace SyndicateProject.Game.GameFlow.UI
{
    public class GameUIPresenter
    {
        private NextItemView _nextItemView;

        public GameUIPresenter(NextItemView nextItemView)
        {
            _nextItemView = nextItemView;
        }

        public void ShowNext(Vector2Int[] shape, Sprite sprite)
        {
            _nextItemView.Show(shape, sprite);
        }
    }
}