using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class LanguageSetDropDown : MonoBehaviour
{
    Dropdown dropdown = null;

    [SerializeField] GameObject button;

    private void Awake()
    {
        dropdown = this.gameObject.GetComponent<Dropdown>();
    }

    private void Start()
    {
        dropdown.options.Clear();
        foreach (var item in LanguageDataSetting.Instance.langugeData)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = item;
            dropdown.options.Add(newData);
        }
    }

    public void OnSetData()
    {
        Debug.Log("Come Void"); 
        SaveLanguagePlayData.SaveIntData(dropdown.value);
        button.SetActive(true);
        if (LanguageDataSetting.Instance.langugeData[dropdown.value] != "Test" 
            || LanguageDataSetting.Instance.langugeData[dropdown.value] != "Debug")
        {
            LanguageDataSetting.Instance.langDataFileName.Value 
                = LanguageDataSetting.Instance.langugeData[dropdown.value];
        }
        StartCoroutine(WaitFrame());
    }

    IEnumerator WaitFrame()
    {
        yield return null;
        SceneController.Instance.m_IsSelectBool = false;
        this.gameObject.SetActive(false);
        yield return null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
