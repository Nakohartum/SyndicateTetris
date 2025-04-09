using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Object = UnityEngine.Object;

namespace SyndicateProject.Game.MainMenu
{
    public class MainMenuPresenter
    {
        private Dictionary<Type, BasicScreen> _screens = new Dictionary<Type, BasicScreen>();
        public event Action OnGameStarted;

        public void InitializeScreens(BasicScreen[] screens, Transform parent)
        {
            foreach (var sc in screens)
            {
                var screen = Object.Instantiate(sc, parent);
                screen.Hide();
                _screens.Add(sc.GetType(), screen);
                InitializeButtons(screen);
            }
        }

        private void InitializeButtons(BasicScreen screen)
        {
            switch (screen)
            {
                case MainMenuView view:
                    view?.StartGameButton.onClick.AddListener(StartGame);
                    view?.LeaderboardButton.onClick.AddListener(OpenLeaderboard);
                    break;
                case LeaderboardView view:
                    view?.BackButton.onClick.AddListener(BackToMenu);
                    break;
            }
        }

        private void BackToMenu()
        {
            HideLeaderboard();
        }

        private void OpenLeaderboard()
        {
            ShowLeaderboard();
        }

        private void StartGame()
        {
            HideMainMenu();
            OnGameStarted();
        }

        public void ShowMainMenu() => _screens[typeof(MainMenuView)].Show();
        
        public void HideMainMenu() => _screens[typeof(MainMenuView)].Hide();
        
        public void ShowLeaderboard() => _screens[typeof(LeaderboardView)].Show();
        public void HideLeaderboard() => _screens[typeof(LeaderboardView)].Hide();
    }
}