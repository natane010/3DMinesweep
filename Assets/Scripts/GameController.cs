using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    public Vector2 rotationSpeed = new Vector2(0.5f, 0.5f);
    public bool reverse;
    public float zoomSpeed = 1;

    private Camera mainCamera;
    private Vector2 lastMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = Input.mouseScrollDelta.y;
        mainCamera.transform.position += -mainCamera.transform.forward * scroll * zoomSpeed;
        if (Input.GetMouseButton(1))
        {
            if (!reverse)
            {
                //Vector3��X,Y�����̉�]�̓x�������`
                Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotationSpeed.x, 
                    Input.GetAxis("Mouse Y") * rotationSpeed.y * -1f, 0);

                //transform.RotateAround()�����悤���ă��C���J��������]������
                mainCamera.transform.RotateAround(targetObject.transform.position, Vector3.up, angle.x);
                mainCamera.transform.RotateAround(targetObject.transform.position, transform.right, angle.y);

            }
            else
            {
                //Vector3��X,Y�����̉�]�̓x�������`
                Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotationSpeed.x,
                    Input.GetAxis("Mouse Y") * rotationSpeed.y * -1f, 0) * -1f;

                //transform.RotateAround()�����悤���ă��C���J��������]������
                mainCamera.transform.RotateAround(targetObject.transform.position, Vector3.up, angle.x);
                mainCamera.transform.RotateAround(targetObject.transform.position, transform.right, angle.y);
            }
        }
    }
}
