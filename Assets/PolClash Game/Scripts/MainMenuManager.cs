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
        
        [Header("Select Level")]
        public GameObject selectLevel;
        public Button selectSchoolGroundButton;
        public Button selectOperaHouseButton;
        public Button selectMaccasButton;
        public Button selectExitButton; // Reset Scene
        
        
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
                    politicalManager = FindObjectOfType<PoliticalManager>();
                    politicalManager.ClearAllOptions();
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
                    OrgainiseSelectLevel();
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
                selectJohnHowardButton.interactable = false;
                MenuSelected(MainMenuMenus.Player2SelectCharacter);
                selectJuliaGillardButton.Select();
            }
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
            {
                politicalManager.player2CharacterSelected = Politician.JohnHoward;
                MenuSelected(MainMenuMenus.SelectLevel);
            }
        }
        public void PlayerSelectJuliaGillard()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
            {
                politicalManager.player1CharacterSelected = Politician.JuliaGillard;
                selectJuliaGillardButton.interactable = false;
                MenuSelected(MainMenuMenus.Player2SelectCharacter);
                selectJohnHowardButton.Select();
            }
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
            {
                politicalManager.player2CharacterSelected = Politician.JuliaGillard;
                MenuSelected(MainMenuMenus.SelectLevel);
            }
        }
        public void PlayerSelectKevinRudd()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
            {
                politicalManager.player1CharacterSelected = Politician.KevinRudd;
                selectKevinRuddButton.interactable = false;
                MenuSelected(MainMenuMenus.Player2SelectCharacter);
                selectJohnHowardButton.Select();
            }
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
            {
                politicalManager.player2CharacterSelected = Politician.KevinRudd;
                MenuSelected(MainMenuMenus.SelectLevel);
            }
        }
        public void PlayerSelectTonyAbort()
        {
            if (MainMenuOpenMenu == MainMenuMenus.Player1SelectCharacter)
            {
                politicalManager.player1CharacterSelected = Politician.TonyAbort;
                selectTonyAbortButton.interactable = false;
                MenuSelected(MainMenuMenus.Player2SelectCharacter);
                selectJohnHowardButton.Select();
            }
            else if (MainMenuOpenMenu == MainMenuMenus.Player2SelectCharacter)
            {
                politicalManager.player2CharacterSelected = Politician.TonyAbort;
                MenuSelected(MainMenuMenus.SelectLevel);
            }
        }
        
        // ORGANISE LEVEL SELECT BUTTONS
        private void OrgainiseSelectLevel()
        {
            selectSchoolGroundButton.onClick.AddListener(LevelSelectSchoolGround);
            selectOperaHouseButton.onClick.AddListener(LevelSelectOperaHouse);
            selectMaccasButton.onClick.AddListener(LevelSelectMaccas);
            selectExitButton.onClick.AddListener(LevelSelectExitButton);
            
            selectSchoolGroundButton.Select();
        }


        private void LevelSelectSchoolGround()
        {
            politicalManager.levelSelected = Level.SchoolGround;
            Debug.Log("Plz Now Load A Level -LOGIC HERE-");
        }

        private void LevelSelectOperaHouse()
        {
            politicalManager.levelSelected = Level.OperaHouse;
            Debug.Log("Plz Now Load A Level -LOGIC HERE-");
        }

        private void LevelSelectMaccas()
        {
            politicalManager.levelSelected = Level.Maccas;
            Debug.Log("Plz Now Load A Level -LOGIC HERE-");
        }
        
        private void LevelSelectExitButton()
        {
            MenuSelected(MainMenuMenus.StartPage);
            Debug.Log("-Please Start Again-");
        }
    }
}
