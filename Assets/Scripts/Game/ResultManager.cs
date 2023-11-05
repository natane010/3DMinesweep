using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Minesweeper;

public class ResultManager : MonoBehaviour
{
    bool isNextSceneLodeCheak = false;

    //[SerializeField] float waitforTime = 3;

    [SerializeField] Text scoreNum;
    [SerializeField] Text topScoreNum;

    private void Start()
    {
        isNextSceneLodeCheak = false;

        Debug.Log(MinGameManager.instance.score);

        scoreNum.text = MinGameManager.instance.score.ToString();

        if (MinGameManager.instance.topScore < MinGameManager.instance.score)
        {
            MinGameManager.instance.SaveScore(MinGameManager.instance.score);

            MinGameManager.instance.topScore = MinGameManager.instance.score;
        }
        Debug.Log(MinGameManager.instance.TopScore);
        topScoreNum.text = MinGameManager.instance.TopScore.ToString();

        StartCoroutine(StartEffectWait());
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isNextSceneLodeCheak)
        {
            isNextSceneLodeCheak = false;
            MinGameManager.instance.ResetScore();
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
