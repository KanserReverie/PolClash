using UnityEngine;

namespace PolClash_Game.Scripts
{
    public class PoliticalManager : MonoBehaviour
    {
        public Politician player1CharacterSelected = Politician.NoPoliticianSelected;
        public Politician player2CharacterSelected = Politician.NoPoliticianSelected;
        public Level levelSelected = Level.NoLevelSelected;
        
        public void ClearAllOptions()
        {
            player1CharacterSelected = Politician.NoPoliticianSelected;
            player2CharacterSelected = Politician.NoPoliticianSelected;
            levelSelected = Level.NoLevelSelected;
        }
    }
}
