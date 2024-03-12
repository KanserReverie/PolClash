using UnityEngine;

namespace PolClash_Game.Scripts
{
    public class PoliticalManager : MonoBehaviour
    {
        public Politician Player1CharacterSelected;
        public Politician Player2CharacterSelected;
        public Level LevelSelected;
        
        public void ClearAllOptions()
        {
            Player1CharacterSelected = new NoPoliticianSelected();
            Player2CharacterSelected = new NoPoliticianSelected();
            LevelSelected = new NoLevelSelected();
        }
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
