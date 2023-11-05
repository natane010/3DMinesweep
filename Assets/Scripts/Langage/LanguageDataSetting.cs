using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UniRx;

//JSONファイルと同じ形式とする。
/*
{
    item1: "hoge1",
    item2: "hoge2"
}
*/
[Serializable]
public class Languages
{
    public string title;
}

[Serializable]
public class LangugeData
{
    public string title;
    public string language;
    public string next;
    public string push;
    public string score;
    public string bestScore;
    public string drag;
    public string click;
    public string bomb;
    public string denger;
    public string safe;
    public string start;
    public string change;
    public string colorsupport;
}

public static class LanguageStructDatas
{
    private static string[] data;

    public static string[] LangData
    {
        get { return data; }
        set { data = value; }
    }
}

[Serializable]
public class LanguageDataSetting : MonoBehaviour
{
    public static LanguageDataSetting Instance = null;

    [SerializeField] string[] languageType;
    
    public const string resourcesPass = "Assets/lang/";

    //JSONファイルのパスを記載する。
    //public string jsonPath = "Assets/Resources/settings.json";

    //JSONファイルのファイル名を記載する。
    //public string jsonfileName = "settings";

    public const string langFileName = "language";
    //public string langDataFileName = "japanese";

    public ReactiveProperty<string> langDataFileName 
        = new ReactiveProperty<string>("Japanese");

    public LangugeData data = null;

    [NonSerialized] public string[] langugeData;
    //[NonSerialized] public string[] selectionlangData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SaveSettings(langFileName);
        //Loadlangage();
        string jsonPath = resourcesPass + langFileName + ".json";


        Loadlangage();

        this.langugeData = OnlyLodeJson(jsonPath);

        langDataFileName.Subscribe(_ => Loadlangage());

        
    }

    void SetLang()
    {
        string jsonPath = resourcesPass + langDataFileName.Value + ".json";

        //Debug.Log("setPath = " + jsonPath);

        //selectionlangData = OnlyLodeJson(jsonPath);

        LoadLangData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region convert use
    //JSONファイルを上書き保存する。
    public void SaveSettings(string fileName)
    {
        //書き込み元データを取得する。ここではsettings.jsonという
        string jsonData = Resources.Load<TextAsset>(fileName).ToString();

        //JSONデータをオブジェクトに変換する
        Languages settingJson = JsonUtility.FromJson<Languages>(jsonData);

        //データを書き込む
        //settingJson.item = "hogehoge";//書き込む内容
        //settingJson.item2 = "hogehoge2";//書き込む内容

        //stringに変換する
        string jsonstr = JsonUtility.ToJson(settingJson);

        //ファイル書き込み用のライターを開く
        StreamWriter writer = new StreamWriter("Assets/Resources/" + fileName + ".json", false);

        //書き込み
        writer.Write(jsonstr);

        //ライターを閉じる処理
        writer.Flush();
        writer.Close();

    }

    //JSONファイルを読み込む。
    private void Loadlangage()
    {

        string jsonPath = resourcesPass + langDataFileName.Value + ".json";
        string jsonPath2 = langDataFileName.Value;

        //Debug.Log("Language : jsonPath : " + jsonPath);

        //ファイル名が間違ってる場合はエラーを出しとく
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return;
        //}

        //JSONファイルを読み込む
        //var json = File.ReadAllText(jsonPath);
        var json = Resources.Load<TextAsset>(jsonPath2).ToString();

        Debug.Log(json);

        //オブジェクト化する
        var obj = JsonUtility.FromJson<LangugeData>(json);

        data = obj;

        //適当な変数に入れる
        var item1 = obj.title;

        //デバッグに表示する。
        //Debug.Log(item1);
    }

    private void LoadLangData()
    {
        string jsonPath = resourcesPass + langDataFileName.Value + ".json";
        string jsonPath2 = langDataFileName.Value;
        //ファイル名が間違ってる場合はエラーを出しとく
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return;
        //}

        //JSONファイルを読み込む
        //var json = File.ReadAllText(jsonPath);
        var json = Resources.Load<TextAsset>(jsonPath2).ToString();

        //オブジェクト化する
        var obj = JsonUtility.FromJson<Languages>(json);

        //適当な変数に入れる
        var item1 = obj.title;

        //デバッグに表示する。
        //Debug.Log(item1);


        //selectionlangData[0] = item1;
    }

    #endregion

    private string[] OnlyLodeJson(string jsonPath)
    {
        //ファイル名が間違ってる場合はエラーを出しとく
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return null;
        //}

        //JSONファイルを読み込む
        //var json = File.ReadAllText(jsonPath);
        var json = Resources.Load<TextAsset>(langFileName).ToString();
        //Debug.Log(json);

        json = json.Replace("{", "");
        json = json.Replace("}", "");

        json = json.Trim();
        //Debug.Log(json);

        string[] array = json.Split(',');

        

        return array;
    }

    private void OnlySaveJson(string jsonPath)
    {
        string jsonstr;

        jsonstr = "{ ";

        foreach (var item in languageType)
        {
            jsonstr += item + ",";
        }
        jsonstr += "Debug }";

        //ファイル書き込み用のライターを開く
        StreamWriter writer = 
            new StreamWriter(jsonPath, false);

        //書き込み
        writer.Write(jsonstr);

        //ライターを閉じる処理
        writer.Flush();
        writer.Close();
    }

}