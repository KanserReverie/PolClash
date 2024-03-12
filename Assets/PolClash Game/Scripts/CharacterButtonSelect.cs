using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PolClash_Game.Scripts
{
    public class CharacterButtonSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        public GameObject p1ImageToTurnOn;
        public GameObject p2ImageToTurnOn;

        private void OnEnable()
        {
            if (p1ImageToTurnOn != null)
            {
                p1ImageToTurnOn.gameObject.SetActive(false);
            }

            if (p2ImageToTurnOn != null)
            {
                p2ImageToTurnOn.gameObject.SetActive(false);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            SelectCharacter();
        }

        public void SelectCharacter()
        {
            if (MainMenuManager.MainMenuOpenMenu == MainMenuManager.MainMenuMenus.Player1SelectCharacter)
            {
                if (p1ImageToTurnOn != null) 
                {
                    p1ImageToTurnOn.gameObject.SetActive(true);
                }
                if (p2ImageToTurnOn != null) 
                {
                    p2ImageToTurnOn.gameObject.SetActive(false);
                }
            }
            if (MainMenuManager.MainMenuOpenMenu == MainMenuManager.MainMenuMenus.Player2SelectCharacter)
            {
                if (p1ImageToTurnOn != null) 
                {
                    p1ImageToTurnOn.gameObject.SetActive(false);
                }
                if (p2ImageToTurnOn != null) 
                {
                    p2ImageToTurnOn.gameObject.SetActive(true);
                }
            }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (p1ImageToTurnOn != null)
            {
                p1ImageToTurnOn.gameObject.SetActive(false);
            }

            if (p2ImageToTurnOn != null)
            {
                p2ImageToTurnOn.gameObject.SetActive(false);
            }
        }
    }
}
