using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    int _SceneNumber = 0;

    private AsyncOperation _SceneAsync;

    public bool m_IsSelectBool = false;

    public bool DebugSceneMode = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
    }

    void Start()
    {
        if (DebugSceneMode)
        {
            return;
        }
        _SceneNumber = 0;
        _SceneNumber++;
        StartLoadScene(_SceneNumber);
        DontDestroyOnLoad(this);
    }

    void StartLoadScene(int number)
    {
        _SceneAsync = SceneManager.LoadSceneAsync(_SceneList[number].name);

        _SceneAsync.allowSceneActivation = false;
    }

    void StartChangeScene()
    {
        _SceneAsync.allowSceneActivation = true;
    }

    public void OnChangeScene(int number)
    {
        //SceneManager.LoadSceneAsync
    }

    private void Update()
    {
        if (DebugSceneMode)
        {
            return;
        }

        int num = _SceneNumber - 1 >= 0 ? _SceneNumber - 1 : _SceneList.Length - 1;

        if (_SceneList[num].name == _StartSceneName)
        {
            if (Input.anyKey && !m_IsSelectBool)
            {
                StartCoroutine(WaitSceneChange());
            }
        }
    }

    public IEnumerator WaitSceneChange()
    {
        yield return StartCoroutine(OnlyCoroutin());
        if (!m_IsSelectBool)
        {

            Debug.Log("ChangeScene");
            StartChangeScene();
            _SceneNumber++;
            _SceneNumber = _SceneNumber > _SceneList.Length ? 0 : _SceneNumber;
        }
    }

    IEnumerator OnlyCoroutin()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
