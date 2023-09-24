using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class MinGameManager : MonoBehaviour
    {
        public static MinGameManager instance = null;

        public bool isResult = true;

        private void Awake()
        {
            if (instance == null)
            {
                instance = new MinGameManager();
            }
            else
            {
                Destroy(this);
            }
            DontDestroyOnLoad(this);
        }

        private void Start()
        {

        }


    }
}
