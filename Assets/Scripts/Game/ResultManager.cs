using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneController.Instance.LoadScene();
            //StartCoroutine(SceneController.Instance.StandardSceneChange());
        }
    }
}
