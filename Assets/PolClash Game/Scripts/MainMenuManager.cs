using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PolClash_Game.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuMenus MainMenuOpenMenu = MainMenuMenus.None;
        [Header("Start Page")]
        public GameObject startPage;
        public Button startPageStartButton;
        public Button startPageExitButton;
        
        [Header("Select Character")]
        public GameObject selectCharacter;
        public Button selectJohnHowardButton;
        public Button selectJuliaGillardButton;
        public Button selectKevinRuddButton;
        public Button selectTonyAbortButton;
        
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
                    MainMenuOpenMenu = MainMenuMenus.StartPage;
                    break;
                case MainMenuMenus.Player1SelectCharacter:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(true);
                    selectLevel.gameObject.SetActive(false);
                    MainMenuOpenMenu = MainMenuMenus.Player1SelectCharacter;
                    OrgainisePlayer1SelectCharacter();
                    break;
                case MainMenuMenus.Player2SelectCharacter:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(true);
                    selectLevel.gameObject.SetActive(false);
                    MainMenuOpenMenu = MainMenuMenus.Player2SelectCharacter;
                    break;
                case MainMenuMenus.SelectLevel:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(false);
                    selectLevel.gameObject.SetActive(true);
                    MainMenuOpenMenu = MainMenuMenus.SelectLevel;
                    break;
                case MainMenuMenus.None:
                    startPage.gameObject.SetActive(false);
                    selectCharacter.gameObject.SetActive(false);
                    selectLevel.gameObject.SetActive(false);
                    MainMenuOpenMenu = MainMenuMenus.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(menu), menu, null);
            }
        }


        private void Start()
        {
            MenuSelected(MainMenuMenus.StartPage);
            politicalManager = FindObjectOfType<PoliticalManager>();
            OrgainiseStartPage();
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
        
        // CHARACTER SELECT BUTTONS
        private void OrgainisePlayer1SelectCharacter()
        {
            selectJohnHowardButton.onClick.AddListener(PlayerSelectJohnHoward);
            selectJuliaGillardButton.onClick.AddListener(PlayerSelectJuliaGillard);
            selectKevinRuddButton.onClick.AddListener(PlayerSelectKevinRudd);
            selectTonyAbortButton.onClick.AddListener(PlayerSelectTonyAbort);
            
            selectJohnHowardButton.Select();
        }
        public void PlayerSelectJohnHoward()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
            {
                politicalManager.player1CharacterSelected = Politician.JohnHoward;
            }
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
                politicalManager.player2CharacterSelected = Politician.JohnHoward;
        }
        public void PlayerSelectJuliaGillard()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
                politicalManager.player1CharacterSelected = Politician.JuliaGillard;
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
                politicalManager.player2CharacterSelected = Politician.JuliaGillard;
        }
        public void PlayerSelectKevinRudd()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
                politicalManager.player1CharacterSelected = Politician.KevinRudd;
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
                politicalManager.player2CharacterSelected = Politician.KevinRudd;
        }
        public void PlayerSelectTonyAbort()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
                politicalManager.player1CharacterSelected = Politician.TonyAbort;
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
                politicalManager.player2CharacterSelected = Politician.TonyAbort;
        }
    }
}
