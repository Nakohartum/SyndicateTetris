using SyndicateProject.Game.GameFlow.Models;
using UnityEngine;
using UnityEngine.UI;

namespace SyndicateProject.Game.GameFlow.Spawn
{
    public class Spawner
    {
        private GameObject _prefab;
        public Tetromino NextTetromino { get; private set; }
        private Sprite[] _sprites;

        public Spawner(GameObject prefab, Sprite[] sprites)
        {
            _prefab = prefab;
            _sprites = sprites;
        }

        private static readonly Vector2Int[][] _shapes = new[]
        {
            // O-shape
            new[]
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0),
                new Vector2Int(0, 1), new Vector2Int(1, 1)
            },

            // I-shape
            new[]
            {
                new Vector2Int(-1, 0), new Vector2Int(0, 0),
                new Vector2Int(1, 0), new Vector2Int(2, 0)
            },

            // T-shape
            new[]
            {
                new Vector2Int(-1, 0), new Vector2Int(0, 0),
                new Vector2Int(1, 0), new Vector2Int(0, 1)
            },

            // L-shape
            new[]
            {
                new Vector2Int(-1, 0), new Vector2Int(0, 0),
                new Vector2Int(1, 0), new Vector2Int(1, 1)
            },

            // J-shape
            new[]
            {
                new Vector2Int(-1, 1), new Vector2Int(-1, 0),
                new Vector2Int(0, 0), new Vector2Int(1, 0)
            },

            // S-shape
            new[]
            {
                new Vector2Int(0, 0), new Vector2Int(1, 0),
                new Vector2Int(-1, 1), new Vector2Int(0, 1)
            },

            // Z-shape
            new[]
            {
                new Vector2Int(-1, 0), new Vector2Int(0, 0),
                new Vector2Int(0, 1), new Vector2Int(1, 1)
            }
        };

        public void SpawnShape()
        {
            var randomIndex = UnityEngine.Random.Range(0, _shapes.Length);
            var shape = _shapes[randomIndex];
            var sprite = _sprites[UnityEngine.Random.Range(0, _sprites.Length)];
            NextTetromino = new Tetromino(_prefab, shape, sprite);
        }
    }
}