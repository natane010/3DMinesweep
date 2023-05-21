using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject targetObject;
    [SerializeField] float zoomSpeed = 1;
    private Camera mainCamera;
    [SerializeField] bool reverse;
    [SerializeField] Vector2 rotationSpeed;
    private Vector2 lastMousePosition;


    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            if (!reverse)
            {
                var x = (Input.mousePosition.y - lastMousePosition.y);
                var y = (lastMousePosition.x - Input.mousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (lastMousePosition.y - Input.mousePosition.y);
                var y = (Input.mousePosition.x - lastMousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                targetObject.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
        }

        CameraZoom();
    }


    void CameraZoom()
    {
        var scroll = Input.mouseScrollDelta.y;
        mainCamera.transform.position += mainCamera.transform.forward * scroll * zoomSpeed * -1f;
    }
}
