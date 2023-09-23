using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
public class LangConverter : MonoBehaviour
{
    enum langDataName
    {
        title,
        language,
        next,
        push,
        score,
        bestScore,
        drag,
        click,
        bomb,
        denger,
        safe,
        start
    }

    [SerializeField] langDataName dataName = 0;

    [SerializeField] Text text;
    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();

        LanguageDataSetting.Instance.langDataFileName.Subscribe(_ => ChangeLang());
    }

    void ChangeLang()
    {
        Debug.Log("Change Lang : " + gameObject.name);

        StartCoroutine(Setbuffer());
    }
    IEnumerator Setbuffer()
    {
        yield return null;
        //text.text = LanguageDataSetting.Instance.data.;

        switch (dataName)
        {
            case langDataName.title:
                text.text = LanguageDataSetting.Instance.data.title;
                break;
            case langDataName.language:
                text.text = LanguageDataSetting.Instance.data.language;
                break;
            case langDataName.next:
                text.text = LanguageDataSetting.Instance.data.next;
                break;
            case langDataName.push:
                text.text = LanguageDataSetting.Instance.data.push;
                break;
            case langDataName.score:
                text.text = LanguageDataSetting.Instance.data.score;
                break;
            case langDataName.bestScore:
                text.text = LanguageDataSetting.Instance.data.bestScore;
                break;
            case langDataName.drag:
                text.text = LanguageDataSetting.Instance.data.drag;
                break;
            case langDataName.click:
                text.text = LanguageDataSetting.Instance.data.click;
                break;
            case langDataName.bomb:
                text.text = LanguageDataSetting.Instance.data.bomb;
                break;
            case langDataName.denger:
                text.text = LanguageDataSetting.Instance.data.denger;
                break;
            case langDataName.safe:
                text.text = LanguageDataSetting.Instance.data.safe;
                break;
            case langDataName.start:
                text.text = LanguageDataSetting.Instance.data.start;
                break;
            default:
                Debug.LogWarning("not selected object");
                break;
        }
        Debug.Log("settex : " + text.text);
    }
}
