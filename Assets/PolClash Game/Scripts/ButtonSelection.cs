using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PolClash_Game.Scripts
{
    public class ButtonSelection : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        public Image imageToTurnOn;
        public void OnSelect(BaseEventData eventData)
        {
            if (imageToTurnOn != null)
            {
                imageToTurnOn.gameObject.SetActive(true);
            }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (imageToTurnOn != null)
            {
                imageToTurnOn.gameObject.SetActive(false);
            }
        }
    }
}