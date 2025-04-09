using SyndicateProject.Game.GameFlow.InputController;
using SyndicateProject.Game.GameFlow.Models;
using SyndicateProject.Game.GameFlow.Spawn;
using SyndicateProject.Game.GameFlow.UI;
using UnityEngine;

namespace SyndicateProject.Game.GameFlow
{
    public class GameFlow
    {
        private TetrisGrid _tetrisGrid;
        private Tetromino _currentTetromino;
        private Spawner _spawner;
        private readonly float _moveTimer;
        private float _currentMoveTimer;
        private InputController.InputController _inputController;
        private GameUIPresenter _gameUIPresenter;

        public GameFlow(TetrisGrid tetrisGrid, Spawner spawner, float moveTimer, GameUIPresenter gameUIPresenter)
        {
            _tetrisGrid = tetrisGrid;
            _spawner = spawner;
            _moveTimer = moveTimer;
            _gameUIPresenter = gameUIPresenter;
            _spawner.SpawnShape();
            SpawnNewTetrimono();
            _inputController = new InputController.InputController();
        }

        public void Update()
        {
            HandleInput();
            
            _currentMoveTimer -= Time.deltaTime;
            if (_currentMoveTimer > 0)
            {
                return;
            }
            _currentTetromino.Move(Vector2Int.down);
            if (!_tetrisGrid.IsPlaceAvailable(_currentTetromino))
            {
                _currentTetromino.Move(Vector2Int.up);
                _tetrisGrid.PlaceTetromino(_currentTetromino);
                _tetrisGrid.ClearFullLines();
                SpawnNewTetrimono();
            }
            _currentMoveTimer = _moveTimer;
        }

        private void SpawnNewTetrimono()
        {
            _currentTetromino = _spawner.NextTetromino;
            _spawner.SpawnShape();
            _currentTetromino.Position = new Vector2Int(_tetrisGrid.Width / 2, _tetrisGrid.Height - 2);
            _currentTetromino.CreateVisuals();
            _gameUIPresenter.ShowNext(_spawner.NextTetromino.Shape, _spawner.NextTetromino.Sprite);
        }

        private void HandleInput()
        {
            var inputState = _inputController.GetInput();
            if (inputState.SwipeLeft)
            {
                TryMove(Vector2Int.left);
            }

            if (inputState.SwipeRight)
            {
                TryMove(Vector2Int.right);
            }

            if (inputState.SwipeUp)
            {
                TryRotate();
            }

            if (inputState.SwipeDown)
            {
                HardDrop();
            }
        }

        private void HardDrop()
        {
            while (_tetrisGrid.IsPlaceAvailable(_currentTetromino))
            {
                _currentTetromino.Move(Vector2Int.down);
            }
            _currentTetromino.Move(Vector2Int.up);
            _tetrisGrid.PlaceTetromino(_currentTetromino);
        }

        private void TryRotate()
        {
            _currentTetromino.Rotate();
            if (!_tetrisGrid.IsPlaceAvailable(_currentTetromino))
            {
                _currentTetromino.RotateBack();
            }
        }

        private void TryMove(Vector2Int dir)
        {
            _currentTetromino.Move(dir);
            if (!_tetrisGrid.IsPlaceAvailable(_currentTetromino))
            {
                _currentTetromino.Move(-dir);
            }
        }
    }
}