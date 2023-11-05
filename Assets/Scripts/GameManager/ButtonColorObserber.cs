using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Minesweeper;

public class ButtonColorObserber : MonoBehaviour
{
    [SerializeField] Image image;

    private void Update()
    {
        if (MinGameManager.instance.isColorChange)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
