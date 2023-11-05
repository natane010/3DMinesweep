using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UniRx;

//JSON�t�@�C���Ɠ����`���Ƃ���B
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

    //JSON�t�@�C���̃p�X���L�ڂ���B
    //public string jsonPath = "Assets/Resources/settings.json";

    //JSON�t�@�C���̃t�@�C�������L�ڂ���B
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
    //JSON�t�@�C�����㏑���ۑ�����B
    public void SaveSettings(string fileName)
    {
        //�������݌��f�[�^���擾����B�����ł�settings.json�Ƃ���
        string jsonData = Resources.Load<TextAsset>(fileName).ToString();

        //JSON�f�[�^���I�u�W�F�N�g�ɕϊ�����
        Languages settingJson = JsonUtility.FromJson<Languages>(jsonData);

        //�f�[�^����������
        //settingJson.item = "hogehoge";//�������ޓ��e
        //settingJson.item2 = "hogehoge2";//�������ޓ��e

        //string�ɕϊ�����
        string jsonstr = JsonUtility.ToJson(settingJson);

        //�t�@�C���������ݗp�̃��C�^�[���J��
        StreamWriter writer = new StreamWriter("Assets/Resources/" + fileName + ".json", false);

        //��������
        writer.Write(jsonstr);

        //���C�^�[����鏈��
        writer.Flush();
        writer.Close();

    }

    //JSON�t�@�C����ǂݍ��ށB
    private void Loadlangage()
    {

        string jsonPath = resourcesPass + langDataFileName.Value + ".json";
        string jsonPath2 = langDataFileName.Value;

        //Debug.Log("Language : jsonPath : " + jsonPath);

        //�t�@�C�������Ԉ���Ă�ꍇ�̓G���[���o���Ƃ�
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return;
        //}

        //JSON�t�@�C����ǂݍ���
        //var json = File.ReadAllText(jsonPath);
        var json = Resources.Load<TextAsset>(jsonPath2).ToString();

        Debug.Log(json);

        //�I�u�W�F�N�g������
        var obj = JsonUtility.FromJson<LangugeData>(json);

        data = obj;

        //�K���ȕϐ��ɓ����
        var item1 = obj.title;

        //�f�o�b�O�ɕ\������B
        //Debug.Log(item1);
    }

    private void LoadLangData()
    {
        string jsonPath = resourcesPass + langDataFileName.Value + ".json";
        string jsonPath2 = langDataFileName.Value;
        //�t�@�C�������Ԉ���Ă�ꍇ�̓G���[���o���Ƃ�
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return;
        //}

        //JSON�t�@�C����ǂݍ���
        //var json = File.ReadAllText(jsonPath);
        var json = Resources.Load<TextAsset>(jsonPath2).ToString();

        //�I�u�W�F�N�g������
        var obj = JsonUtility.FromJson<Languages>(json);

        //�K���ȕϐ��ɓ����
        var item1 = obj.title;

        //�f�o�b�O�ɕ\������B
        //Debug.Log(item1);


        //selectionlangData[0] = item1;
    }

    #endregion

    private string[] OnlyLodeJson(string jsonPath)
    {
        //�t�@�C�������Ԉ���Ă�ꍇ�̓G���[���o���Ƃ�
        //if (!File.Exists(jsonPath))
        //{
        //    Debug.Log("setting File not Exists");
        //    return null;
        //}

        //JSON�t�@�C����ǂݍ���
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

        //�t�@�C���������ݗp�̃��C�^�[���J��
        StreamWriter writer = 
            new StreamWriter(jsonPath, false);

        //��������
        writer.Write(jsonstr);

        //���C�^�[����鏈��
        writer.Flush();
        writer.Close();
    }

}