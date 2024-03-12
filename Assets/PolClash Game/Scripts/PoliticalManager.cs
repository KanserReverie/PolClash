using UnityEngine;

namespace PolClash_Game.Scripts
{
    public class PoliticalManager : MonoBehaviour
    {
        public Politician player1CharacterSelected;
        public Politician player2CharacterSelected;
        public Level LevelSelected;
        
        public void ClearAllOptions()
        {
            player1CharacterSelected = Politician.NoPoliticianSelected;
            player2CharacterSelected = Politician.NoPoliticianSelected;
            LevelSelected = new NoLevelSelected();
        }
    }
}
