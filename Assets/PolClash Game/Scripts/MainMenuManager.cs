using UnityEngine;

namespace PolClash_Game.Scripts
{
    public class MainMenuManager : MonoBehaviour
    {
        /// <summary>
        /// In build - Exits the game
        /// In playmode - Ends the playmode 
        /// </summary>
        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
    }
}
