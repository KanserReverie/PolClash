using System;
using UnityEngine;

namespace PolClash_Game.Scripts
{
    public class LevelSpawner : MonoBehaviour
    {
        public GameObject schoolGround;
        public GameObject operaHouse;
        public GameObject maccas;
        // Start is called before the first frame update
        void Start()
        {
            schoolGround.SetActive(false);
            operaHouse.SetActive(false);
            maccas.SetActive(false);

            PoliticalManager sceneSetup = FindObjectOfType<PoliticalManager>();
            
            if (sceneSetup == null)
            {
                schoolGround.gameObject.SetActive(true);
            }
            else
            {
                switch (sceneSetup.levelSelected)
                {
                    case Level.SchoolGround:
                        schoolGround.SetActive(true);
                        break;
                    case Level.OperaHouse:
                        operaHouse.SetActive(true);
                        break;
                    case Level.Maccas:
                        maccas.SetActive(true);
                        break;
                    case Level.NoLevelSelected:
                        schoolGround.SetActive(true);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
