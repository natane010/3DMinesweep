using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject rotateObj;
    [SerializeField] GameObject subrootObj;
    
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject subtargetObject;
    [SerializeField] float zoomSpeed = 1;
    private Camera mainCamera;
    [SerializeField] bool reverse;
    [SerializeField] Vector2 rotationSpeed;
    private Vector2 lastMousePosition;

    public static Vector2 lastVector;

    void Start()
    {
        mainCamera = Camera.main;
        lastVector = Vector2.zero;
    }

    void Update()
    {
        //MouseBottonMove();

        MoveMovementMouse();

        CameraZoom();
    }

    void MoveMovementMouse()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GetSetVector();
        }
        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                var x = (Input.mousePosition.y - lastMousePosition.y);
                var y = (lastMousePosition.x - Input.mousePosition.x);

                if (lastVector == new Vector2(x, y))
                {
                    VectorReset();
                    GetSetVector();
                    return;
                }
                else
                {
                    lastVector = new Vector2(x, y);
                }
                
                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                rotateObj.transform.Rotate(newAngle);
                subrootObj.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (lastMousePosition.y - Input.mousePosition.y);
                var y = (Input.mousePosition.x - lastMousePosition.x);

                if (lastVector == new Vector2(x, y))
                {
                    VectorReset();
                    GetSetVector();
                    return;
                }
                else
                {
                    lastVector = new Vector2(x, y);
                }

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                rotateObj.transform.Rotate(newAngle);
                subrootObj.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            VectorReset();
        }

    }

    void GetSetVector()
    {
        lastMousePosition = Input.mousePosition;
        targetObject.transform.parent = rotateObj.transform;
        subtargetObject.transform.parent = subrootObj.transform;
    }

    void VectorReset()
    {
        targetObject.transform.parent = null;
        subtargetObject.transform.parent = null;
        rotateObj.transform.rotation = Quaternion.identity;
        subrootObj.transform.rotation = Quaternion.identity;
        lastVector = Vector2.zero;
    }

    void MouseBottonMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
            targetObject.transform.parent = rotateObj.transform;
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

                rotateObj.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                var x = (lastMousePosition.y - Input.mousePosition.y);
                var y = (Input.mousePosition.x - lastMousePosition.x);

                var newAngle = Vector3.zero;
                newAngle.x = x * rotationSpeed.x;
                newAngle.y = y * rotationSpeed.y;

                rotateObj.transform.Rotate(newAngle);
                lastMousePosition = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            targetObject.transform.parent = null;
            rotateObj.transform.rotation = Quaternion.identity;
        }
    }

    void CameraZoom()
    {
        var scroll = Input.mouseScrollDelta.y;
        mainCamera.transform.position += mainCamera.transform.forward * scroll * zoomSpeed * -1f;
    }
}
