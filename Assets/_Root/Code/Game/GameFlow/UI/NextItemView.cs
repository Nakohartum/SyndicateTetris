using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SyndicateProject.Game.GameFlow.UI
{
    public class NextItemView : MonoBehaviour
    {
        [SerializeField] private RectTransform _root;
        [SerializeField] private Image _image;
        
        private List<GameObject> _items = new List<GameObject>();

        public void Show(Vector2Int[] shape, Sprite sprite)
        {
            Clear();
            int minX = shape.Min(v => v.x);
            int maxX = shape.Max(v => v.x);
            int minY = shape.Min(v => v.y);
            int maxY = shape.Max(v => v.y);
            float centerX = (minX + maxX) / 2f;
            float centerY = (minY + maxY) / 2f;
            foreach (Vector2 shapePoint in shape)
            {
                var block = Instantiate(_image, _root);
                Vector2 localOffset = new Vector2(shapePoint.x - centerX, shapePoint.y - centerY);
                block.GetComponent<RectTransform>().anchoredPosition = localOffset * _image.rectTransform.sizeDelta;
                block.sprite = sprite;
                _items.Add(block.gameObject);
            }
        }

        private void Clear()
        {
            foreach (var item in _items)
            {
                Destroy(item);
            }
            _items.Clear();
        }
    }
}