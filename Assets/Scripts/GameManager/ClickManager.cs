using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper.Sound
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();
            }
        }
    }
}
