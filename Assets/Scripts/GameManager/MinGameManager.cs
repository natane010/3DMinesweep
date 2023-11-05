using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class MinGameManager : MonoBehaviour
    {
        public static MinGameManager instance = null;

        public const string scoreKey = "memory:score";

        public bool isColorChange = false;

        public int score;

        public int topScore = 0;

        public int TopScore => LodeScore();

        [SerializeField] int AddCount = 10;

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

            topScore = LodeScore();
        }


        public void AddScore()
        {
            score += AddCount;
        }

        public void ResetScore()
        {
            score = 0;
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


        public void IsChangeColor()
        {
            SceneController.Instance.m_IsSelectBool = true;
            isColorChange = isColorChange ? false : true;
            StartCoroutine(WaitOneFrame());
            SceneController.Instance.m_IsSelectBool = false;
        }

        IEnumerator WaitOneFrame()
        {
            yield return null;
        }
    }
}
