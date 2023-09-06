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
    [SerializeField] SceneData[] _SceneList;
    [SerializeField] string _StartSceneName = "Start";

    int _SceneNumber = 0;

    private AsyncOperation _SceneAsync;

    void Start()
    {
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
        if (_SceneList[_SceneNumber - 1].name == _StartSceneName)
        {
            if (Input.anyKey)
            {
                Debug.Log("ChangeScene");
                StartChangeScene();
                _SceneNumber++;
                _SceneNumber = _SceneNumber > _SceneList.Length ? 0 : _SceneNumber;
            }
        }
    }
}
