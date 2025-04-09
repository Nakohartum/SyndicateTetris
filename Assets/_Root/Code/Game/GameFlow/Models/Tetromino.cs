using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SyndicateProject.Game.GameFlow.Models
{
    public class Tetromino
    {
        public Vector2Int[] Shape;
        private List<GameObject> _visuals = new List<GameObject>();
        private int _rotationIndex;
        private GameObject _prefab;
        public Sprite Sprite;
        public Vector2Int Position;

        public Tetromino(GameObject prefab, Vector2Int[] shape, Sprite sprite)
        {
            _prefab = prefab;
            Shape = shape;
            Sprite = sprite;
        }

        public void CreateVisuals()
        {
            foreach (var offset in Shape)
            {
                var worldPos = offset + Position;
                var obj = Object.Instantiate(_prefab, new Vector3(worldPos.x, worldPos.y), Quaternion.identity);
                obj.GetComponentInChildren<SpriteRenderer>().sprite = Sprite;
                _visuals.Add(obj);
            }
        }

        private void UpdateVisuals()
        {
            for (int i = 0; i < _visuals.Count; i++)
            {
                var pos = Shape[i] + Position;
                _visuals[i].transform.position = new Vector3(pos.x, pos.y, 0);
            }
        }
        
        public Vector2Int[] GetWorldPosition() => Shape.Select(offset => offset + Position).ToArray();

        public void Move(Vector2Int position)
        {
            Position += position;
            UpdateVisuals();
        }

        public void Rotate()
        {
            Rotate90();
            UpdateVisuals();
        }

        public void RotateBack()
        {
            Rotate90(true);
            UpdateVisuals();
        }

        private void Rotate90(bool clockwise = false)
        {
            for (int i = 0; i < Shape.Length; i++)
            {
                int x = Shape[i].x;
                int y = Shape[i].y;
                Shape[i] = clockwise ? new Vector2Int(y, -x) : new Vector2Int(-y, x);
            }
        }

        public GameObject GetVisualAtPos(Vector2Int pos)
        {
            return _visuals.First(go => go.transform.position == new Vector3(pos.x, pos.y));
        }
    }
}