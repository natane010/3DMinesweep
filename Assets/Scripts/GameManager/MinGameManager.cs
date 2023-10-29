using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class MinGameManager : MonoBehaviour
    {
        public static MinGameManager instance = null;

        public const string scoreKey = "memory:score"; 

        public int score;

        public bool isResult = true;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
#if UNITY_EDITOR
            PlayerPrefs.DeleteKey(scoreKey);
#endif
        }


        public int LodeScore()
        {
            PlayerPrefs.GetInt(scoreKey, 0);
            return score;
        }
        public void SaveScore(int HightScore)
        {
            PlayerPrefs.SetInt(scoreKey, HightScore);
        }

    }
}
