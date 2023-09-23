using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum locarizeSystem
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
    safe
}

[System.Serializable]
public class Langlocarize : MonoBehaviour
{
    [SerializeField] locarizeSystem setTag;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(WaitData());
    }

    IEnumerator WaitData()
    {
        bool isSet = false;
        while (!isSet)
        {
            yield return null;
            if (LanguageDataSetting.Instance.data != null)
            {
                SetupLanguage();
                isSet = true;
            }
        }
    }

    void SetupLanguage()
    {
        var data = LanguageDataSetting.Instance.data;

        //var str = data.Data(setTag);

        //text.text = str;
    }
}
