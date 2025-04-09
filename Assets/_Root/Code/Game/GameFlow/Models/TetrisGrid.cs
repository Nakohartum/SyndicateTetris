using System.Collections.Generic;
using UnityEngine;

namespace SyndicateProject.Game.GameFlow.Models
{
    public class TetrisGrid
    {
        private bool[,] _grid;
        public int Height;
        public int Width;
        private Dictionary<Vector2Int, GameObject> _gameObjects = new Dictionary<Vector2Int, GameObject>();

        public TetrisGrid(int height, int width)
        {
            Height = height;
            Width = width;
            _grid = new bool[Width, Height];
        }

        public bool IsPlaceAvailable(Tetromino t)
        {
            foreach (var pos in t.GetWorldPosition())
            {
                if (pos.x < 0 || pos.x >= Width || pos.y < 0 || pos.y >= Height)
                {
                    return false;
                }
                if (_grid[pos.x,pos.y])
                {
                    return false;
                }
            }

            return true;
        }

        public void PlaceTetromino(Tetromino t)
        {
            foreach (var pos in t.GetWorldPosition())
            {
                if (pos.x >= 0 && pos.x < Width && pos.y >= 0 && pos.y < Height )
                {
                    _grid[pos.x, pos.y] = true;
                    _gameObjects[pos] = t.GetVisualAtPos(pos);
                }
            }
        }

        public void ClearFullLines()
        {
            for (int y = 0; y < Height; y++)
            {
                if (IsFullLine(y))
                {
                    ClearLine(y);
                    ShiftLineDown(y);
                    y--;
                }
            }
        }

        private void ShiftLineDown(int y)
        {
            for (int i = y; i < Height - 1; i++)    
            {
                for (int x = 0; x < Width; x++)
                {
                    var yValue = i;
                    _grid[x, i] = _grid[x, i + 1];
                    ShiftGameObjectDown(x, yValue);
                }
            }

            for (int x = 0; x < Width; x++)
            {
                _grid[x, Height - 1] = false;
            }
        }

        private void ShiftGameObjectDown(int x, int y)
        {
            if (_gameObjects.TryGetValue(new Vector2Int(x, y), out GameObject obj))
            {
                _gameObjects.Remove(new Vector2Int(x, y));
                obj.transform.position += Vector3.down;
                _gameObjects[new Vector2Int(x, y-1)] = obj;
            }
        }

        private void ClearLine(int y)
        {
            for (int x = 0; x < Width; x++)
            {
                _grid[x, y] = false;
                if (_gameObjects.TryGetValue(new Vector2Int(x, y), out GameObject obj))
                {
                    Object.Destroy(obj);
                    _gameObjects.Remove(new Vector2Int(x, y));
                }
            }
        }

        private bool IsFullLine(int i)
        {
            for (int x = 0; x < Width; x++)
            {
                if (!_grid[x, i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}