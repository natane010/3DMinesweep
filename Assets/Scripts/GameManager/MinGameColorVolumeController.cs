using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minesweeper;

public class MinGameColorVolumeController : MonoBehaviour
{
    [SerializeField] GameObject volume;

    void Update()
    {
        if (MinGameManager.instance.isColorChange)
        {
            volume.SetActive(true);
        }   
        else
        {
            volume.SetActive(false);
        }
    }
}
