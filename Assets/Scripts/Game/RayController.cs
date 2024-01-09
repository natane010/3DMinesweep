using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minesweeper;

public class RayController : MonoBehaviour
{
    float time = 0;
    bool isActive;
    bool ContDestroy;
    [SerializeField] GameObject Effect;

    private void Start()
    {
        Effect.SetActive(false);
    }

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
                    Minesweeper.MinGameManager.instance.isResult = false;
                    StartCoroutine(WaitEffect());
                }
                MinGameManager.instance.AddScore();
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
        Effect.SetActive(true);
        yield return null;
        yield return new WaitForSeconds(1f);
    }
}
