using SyndicateProject.Game.GameFlow.Models;
using SyndicateProject.Game.GameFlow.Spawn;
using SyndicateProject.Game.GameFlow.UI;
using UnityEngine;

namespace SyndicateProject.Game.GameFlow
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private float _moveTimer;
        [SerializeField] private Sprite[] _sprites;
        public GameFlow GameFlow { get; private set; }
        public void StartGame(GameUIPresenter presenter)
        {
            var grid = new TetrisGrid(_height, _width);
            var spawner = new Spawner(_prefab, _sprites);
            GameFlow = new GameFlow(grid, spawner, _moveTimer, presenter);
        }
    }
}