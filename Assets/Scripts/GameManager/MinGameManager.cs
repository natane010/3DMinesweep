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

        }


    }
}
