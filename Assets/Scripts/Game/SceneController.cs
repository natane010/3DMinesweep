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

    [SerializeField] int currentNum;

    [SerializeField] AudioSource audioSource;
    static int _SceneNumber = 0;

    private AsyncOperation _SceneAsync;

    private bool isLoadScene = false;

    public bool m_IsSelectBool = false;

    public bool DebugSceneMode = false;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            isLoadScene = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        if (DebugSceneMode)
        {
            return;
        }
    }

    private void Update()
    {
        if (DebugSceneMode)
        {
            return;
        }
        currentNum = _SceneNumber;

        int num = _SceneNumber - 1 >= 0 ? _SceneNumber - 1 : _SceneList.Length - 1;

        if (_SceneList[_SceneNumber].name == _StartSceneName && Input.anyKeyDown && !m_IsSelectBool)
        {
            LoadScene();
        }
    }

    void CountSceneNumber()
    {
        _SceneNumber++;
        Debug.Log(_SceneNumber);
        _SceneNumber = _SceneNumber < _SceneList.Length ? _SceneNumber : 0;
        Debug.Log(_SceneNumber);
    }

    public void LoadScene()
    {
        audioSource.Play();
        if (!isLoadScene)
        {
            StartCoroutine(this.WaitSyncScene());
            Debug.Log(_SceneList[_SceneNumber].name);
        }
    }

    IEnumerator WaitSyncScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (m_IsSelectBool)
        {
            yield break;
        }
        
        isLoadScene = true;
        yield return StartCoroutine(LoadSceneData());
        isLoadScene = false;
    }

    IEnumerator LoadSceneData()
    {
        _loadUI.SetActive(true);
        CountSceneNumber();
        _SceneAsync = SceneManager.LoadSceneAsync(_SceneList[_SceneNumber].name);

        while (!_SceneAsync.isDone)
        {
            var progressVal = Mathf.Clamp01(_SceneAsync.progress / 0.9f);
            _loader.value = progressVal;
            yield return null;
        }
        //Debug.Log(_SceneList[_SceneNumber].name);
        
        _loadUI.SetActive(false);
    }
}
