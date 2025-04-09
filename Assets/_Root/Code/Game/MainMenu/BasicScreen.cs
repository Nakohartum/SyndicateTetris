using UnityEngine;

namespace SyndicateProject.Game.MainMenu
{
    public class BasicScreen : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}