using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneData
{
    public string name = null;
}

[System.Serializable]
public class SceneController : MonoBehaviour
{
    public static SceneController Instance = null;

    [SerializeField] SceneData[] _SceneList;
    [SerializeField] string _StartSceneName = "Start";

    [SerializeField] GameObject _loadUI;
    [SerializeField] Slider _loader;

    static int _SceneNumber = 0;

    private AsyncOperation _SceneAsync;

    private bool isLoadScene = false;

    public bool m_IsSelectBool = false;

    public bool DebugSceneMode = false;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            Destroy(this.gameObject);
        }
        Instance = this;

        if (DebugSceneMode)
        {
            return;
        }
        isLoadScene = false;
        _SceneNumber = 0;
        _SceneNumber++;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (DebugSceneMode)
        {
            return;
        }


        int num = _SceneNumber - 1 >= 0 ? _SceneNumber - 1 : _SceneList.Length - 1;

        if (_SceneList[num].name == _StartSceneName && Input.anyKey && !m_IsSelectBool)
        {
            LoadScene();
        }
    }

    void CountSceneNumber()
    {
        _SceneNumber++;
        _SceneNumber = _SceneNumber < _SceneList.Length ? _SceneNumber : 0;
    }

    public void LoadScene()
    {
        if (!isLoadScene)
        {
            StartCoroutine(this.WaitSyncScene());
            Debug.Log(_SceneList[_SceneNumber].name);
        }
    }

    IEnumerator WaitSyncScene()
    {
        isLoadScene = true;
        yield return StartCoroutine(LoadSceneData());
        isLoadScene = false;
    }

    IEnumerator LoadSceneData()
    {
        _loadUI.SetActive(true);
        _SceneAsync = SceneManager.LoadSceneAsync(_SceneList[_SceneNumber].name);

        while (!_SceneAsync.isDone)
        {
            var progressVal = Mathf.Clamp01(_SceneAsync.progress / 0.9f);
            _loader.value = progressVal;
            yield return null;
        }
        //Debug.Log(_SceneList[_SceneNumber].name);
        CountSceneNumber();
        _loadUI.SetActive(false);
    }
}
