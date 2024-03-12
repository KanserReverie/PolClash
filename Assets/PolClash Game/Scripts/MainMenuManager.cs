using System;
using UnityEngine;
using UnityEngine.UI;

namespace PolClash_Game.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        [Header("Start Page")]
        public GameObject startPage;

        public Button startPageStartButton;
        public Button startPageExitButton;
        
        public GameObject selectCharacter;
        public GameObject selectLevel;
        
        
        private PoliticalManager politicalManager;
        public enum MainMenuMenus{StartPage, Player1SelectCharacter, Player2SelectCharacter, SelectLevel, None}
        public void MenuSelected(MainMenuMenus menu)
        {
            switch (menu)
            {
                case MainMenuMenus.StartPage:
                    startPage.gameObject.SetActive(true);
                    selectCharacter.gameObject.SetActive(false);
                    selectLevel.gameObject.SetActive(false);
                    break;
                case MainMenuMenus.Player1SelectCharacter or MainMenuMenus.Player2SelectCharacter:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(true);
                    selectLevel.gameObject.SetActive(false);
                    break;
                case MainMenuMenus.SelectLevel:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(false);
                    selectLevel.gameObject.SetActive(true);
                    break;
                case MainMenuMenus.None:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(false);
                    selectLevel.gameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(menu), menu, null);
            }
        }

        private void Start()
        {
            MenuSelected(MainMenuMenus.StartPage);
            politicalManager = FindObjectOfType<PoliticalManager>();

            startPageStartButton.Select();
            //OrgainiseStartPage();
        }


        // START PAGE BUTTONS
        private void OrgainiseStartPage()
        {
            startPageStartButton.onClick.AddListener(StartButton);
            startPageExitButton.onClick.AddListener(ExitButton);
            startPageStartButton.Select();
        }
        public void StartButton() { MenuSelected(MainMenuMenus.Player1SelectCharacter); }
        public void ExitButton()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
