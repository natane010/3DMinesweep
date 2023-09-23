using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class MinesweeperCellBase : MonoBehaviour
    {
        internal bool isMine;
        public MinMeshData minMesh;
        public bool IsMine
        {
            get
            {
                return isMine;
            }
            set
            {
                isMine = value;
            }
        }

        internal int numberMineDistance = 0;

        public int NumberMineDistance
        {
            get
            {
                return numberMineDistance;
            }
            set
            {
                numberMineDistance = value;
            }
        }

    }

    [System.Serializable]
    public struct MinMeshData
    {
        public Mesh MinMesh;
        public Mesh YelllowMesh;
        public Mesh SafeMesh;
    }
}
