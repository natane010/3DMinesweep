using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    float time = 0;
    bool isActive;
    bool ContDestroy;
    [SerializeField] GameObject Effect;
    Vector3 pos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ContDestroy = false;
            isActive = true;
            time = 0;
        }
        if (isActive)
        {
            time += Time.deltaTime;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) 
            && Input.GetMouseButtonUp(0) && time < 0.5f
            && GameController.lastVector == Vector2.zero)
        {
            if (!ContDestroy)
            {
                if (hit.collider.gameObject.GetComponent<Minesweeper.CellData>().isMine)
                {
                    pos = hit.collider.gameObject.transform.position;
                    Minesweeper.MinGameManager.instance.isResult = false;
                    StartCoroutine(WaitEffect());
                    //StartCoroutine(SceneController.Instance.WaitSceneChange());
                    //SceneController.Instance.LoadScene();
                }
                //Debug.Log(hit.collider.gameObject.transform.position);
                Destroy(hit.collider.gameObject);
                ContDestroy = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isActive = false;
        }
    }

    IEnumerator WaitEffect()
    {
        yield return StartCoroutine(InstanceEffect());
        SceneController.Instance.LoadScene();
    }

    IEnumerator InstanceEffect()
    {
        yield return null;
        Instantiate(Effect, pos, Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }
}
