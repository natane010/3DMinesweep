using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class MinesweeperController : MonoBehaviour
    {
        [SerializeField] GameObject CellObject;
        [SerializeField] GameObject SampleObject;
        [SerializeField] GameObject SampleObjRoot;

        [SerializeField, Range(0,50)] int mineGameCubeSize = 3;

        [SerializeField, Range(1, 100)] int maxCellCount = 1;
        [SerializeField, Range(1, 100)] int minCellCount = 1;

        [SerializeField] MinMeshData MeshData;

        GameObject[,,] cells;
        CellData[,,] cellDatas;

        public GameObject[,,] CellsData => cells;

        private void Start()
        {
            SetInstanceCell(mineGameCubeSize);
        }

        void SetInstanceCell(int size)
        {
            cells = new GameObject[size, size, size];
            cellDatas = new CellData[size, size, size];

            List<GameObject> samples = new List<GameObject>();

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        var position = new Vector3(
                            (float)(x + 0.1f * x),
                            (float)(y + 0.1f * y),
                            (float)(z + 0.1f * z)
                            );
                        int n = Random.Range(0, 100);
                        cells[x, y, z] = Instantiate(CellObject, position, Quaternion.identity);

                        cellDatas[x, y, z] = cells[x, y, z].GetComponent<CellData>();
                        CellData a = cellDatas[x, y, z];
                        a.minMesh = MeshData;
                        if (n <= (maxCellCount / size ^ 3))
                        {
                            a.IsMine = true;
                            var offs = this.transform.position - SampleObjRoot.transform.position;
                            var sample = Instantiate(SampleObject, position - offs, Quaternion.identity);
                            samples.Add(sample);
                            sample.transform.parent = SampleObjRoot.transform;
                        }
                        else
                        {
                            a.IsMine = false;
                        }
                        cells[x, y, z].transform.parent = this.transform;
                    }
                }
            }



            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        if (cellDatas[x,y,z].isMine)
                        {
                            for (int dx = -1; dx < 2; dx++)
                            {
                                for (int dy = -1; dy < 2; dy++)
                                {
                                    for (int dz = -1; dz < 2; dz++)
                                    {
                                        if (dx == 0 && dy == 0 && dz == 0)
                                        {

                                        }
                                        else
                                        {
                                            var cellnum = new Vector3(x - dx, y - dy, z - dz);
                                            if (NullCheakCell(size, cellnum))
                                            {
                                                cellDatas[x - dx, y - dy, z - dz].numberMineDistance += 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var halfPoint = (cells[0, 0, 0].transform.position + cells[size - 1, size - 1, size - 1].transform.position) / 2;

            foreach (var item in cells)
            {
                item.transform.position -= halfPoint;
            }

            foreach (var item in samples)
            {
                item.transform.position -= halfPoint;
            }

            if (!CheakCells(cellDatas, maxCellCount, minCellCount))
            {
                ResetCell();
                SetInstanceCell(mineGameCubeSize);
            }
        }

        void ResetCell()
        {
            foreach (var item in cells)
            {
                Destroy(item);
            }
        }

        bool CheakCells(CellData[,,] cell, int MaxCount, int MinCount)
        {
            int count = 0;
            foreach (var item in cell)
            {
                if (item.IsMine)
                {
                    count++;
                }
            }
            if (count <= MaxCount && count>= MinCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool NullCheakCell(int max, Vector3 num)
        {
            if (num.x < 0 || num.y < 0 || num.z < 0)
            {
                return false;
            }
            else if (num.x >= max || num.y >= max || num.z >= max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
