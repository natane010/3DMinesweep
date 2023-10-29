using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    bool isNextSceneLodeCheak = false;

    [SerializeField] float waitforTime = 3;

    [SerializeField] Text scoreNum;

    private void Start()
    {
        isNextSceneLodeCheak = false;
        StartCoroutine(StartEffectWait());
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isNextSceneLodeCheak)
        {
            isNextSceneLodeCheak = false;
            SceneController.Instance.LoadScene();
        }
    }

    IEnumerator StartEffectWait()
    {
        while (true)
        {
            if (true)
            {
                break;
            }
        }

        yield return StartCoroutine(StartSceneWait());
        isNextSceneLodeCheak = true;
    }
    IEnumerator StartSceneWait()
    {
        yield return null;
    }
}
