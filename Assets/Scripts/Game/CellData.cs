using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper
{
    public class CellData : MinesweeperCellBase
    {
        MeshFilter meshFilter;
        Material material;
        bool m_GameCheaker = false;

        private void Start()
        {
            material = GetComponent<MeshRenderer>().material;
            meshFilter = GetComponent<MeshFilter>();
            m_GameCheaker = false;
        }
        private void Update()
        {
            if (!m_GameCheaker)
            {
                m_GameCheaker = true;
                LateStart();
            }
        }

        void LateStart()
        {
            if (isMine)
            {
                //material.color = Color.red;
                //return;
            }
            switch (numberMineDistance)
            {
                case 0:
                    meshFilter.mesh = minMesh.SafeMesh;
                    material.color = Color.green;
                    if (!isMine)
                    {
                        Destroy(this.gameObject);
                    } 
                    break;
                case 2:
                    meshFilter.mesh = minMesh.MinMesh;
                    material.color = Color.yellow;
                    break;
                case 1:
                    meshFilter.mesh = minMesh.YelllowMesh;
                    material.color = Color.green;
                    break;
                default:
                    meshFilter.mesh = minMesh.SafeMesh;
                    material.color = Color.green;
                    break;
            }
            if (isMine)
            {
                material.color = Color.red;
                //return;
            }
        }

        //private void OnDestroy()
        //{
        //    if (isMine)
        //    {
        //        //Debug.Log("Booo!!");
        //        //Minesweeper.MinGameManager.instance.isResult = false;
        //        //StartCoroutine(SceneController.Instance.WaitSceneChange());
        //    }
        //}
    }
}
