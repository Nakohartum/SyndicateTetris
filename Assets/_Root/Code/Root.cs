using System;
using AppsFlyerSDK;
using SyndicateProject.Game.GameFlow;
using SyndicateProject.Game.MainMenu;
using UnityEngine;

namespace SyndicateProject
{

    public class Root : MonoBehaviour
    {
        [SerializeField] private MainMenuBootstrap _mainMenuBootstrap;
        [SerializeField] private GameBootstrap _gameBootstrap;
        [SerializeField] private GameUIBootstrap _gameUIBootstrap;
        private GameFlow _gameFlow;
        private bool _initialized;
        private void Start()
        {
            _mainMenuBootstrap.Initialize();
            _mainMenuBootstrap.MainMenuPresenter.ShowMainMenu();
            _mainMenuBootstrap.MainMenuPresenter.OnGameStarted += StartGame;
        }

        private void StartGame()
        {
            _gameUIBootstrap.CreateUI();
            _gameBootstrap.StartGame(_gameUIBootstrap.Presenter);
            _gameFlow = _gameBootstrap.GameFlow;
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized) return;
            _gameFlow.Update();
        }
    }
}