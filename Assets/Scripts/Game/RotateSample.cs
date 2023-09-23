using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSample : MonoBehaviour
{
    [SerializeField] Vector3 moveDir;    

    void Update()
    {
        transform.Rotate(moveDir);
    }
}
