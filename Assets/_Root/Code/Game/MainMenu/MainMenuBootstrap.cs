using System;
using UnityEngine;

namespace SyndicateProject.Game.MainMenu
{
    public class MainMenuBootstrap : MonoBehaviour
    {
        [SerializeField] private BasicScreen[] _basicScreens;
        [SerializeField] private Transform _parent;
        public MainMenuPresenter MainMenuPresenter { get; private set; }

        public void Initialize()
        {
            MainMenuPresenter = new MainMenuPresenter();
            MainMenuPresenter.InitializeScreens(_basicScreens, _parent);
        }
    }
}