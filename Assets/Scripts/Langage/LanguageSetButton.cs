using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSetButton : MonoBehaviour
{
    [SerializeField] GameObject tile = null;

    [SerializeField] Text tex;

    private void Update()
    {
        tex.text = LanguageDataSetting.Instance.langugeData[SaveLanguagePlayData.LanguageNum];
    }

    public void ChangeLang()
    {
        SceneController.Instance.m_IsSelectBool = true;
        if (tile == null)
        {
            SceneController.Instance.m_IsSelectBool = false;
            return;
        }
        tile.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
