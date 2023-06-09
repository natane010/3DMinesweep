using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper
{
    public class CellData : MinesweeperCellBase
    {
        Material material;

        private void Start()
        {
            material = GetComponent<MeshRenderer>().material;
        }
        private void Update()
        {
            if (isMine)
            {
                material.color = Color.green;
            }
            else if (numberMineDistance == 1)
            {
                material.color = Color.green;
            }

        }

        private void OnDestroy()
        {
            if (isMine)
            {
                Debug.Log("Booo!!");
            }
        }
    }
}
