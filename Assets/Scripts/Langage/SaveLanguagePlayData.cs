using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLanguagePlayData : MonoBehaviour
{
    static int settinglanguage = 0;

    public static int LanguageNum
    {
        get
        {
            return settinglanguage;
        }
        private set
        {
            settinglanguage = value;
        }
    }

    void Start()
    {
        var number = PlayerPrefs.GetInt("language", 0);
        LanguageNum = number;
    }

    public static void SaveIntData(int number)
    {
        settinglanguage = number;
        PlayerPrefs.SetInt("language", number);
    }

}
