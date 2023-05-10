using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 1.5f, -2f);
    [SerializeField]
    private float sensitivity = 3f;
    [SerializeField]
    private float distanceFromTarget = 5f;
    [SerializeField]
    private float minYAngle = -20f;
    [SerializeField]
    private float maxYAngle = 80f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set for ThirdPersonCamera script!");
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (target == null)
            return;

        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = scrollWheelInput * 3f;

        distanceFromTarget -= zoomAmount;
        distanceFromTarget = Mathf.Clamp(distanceFromTarget, 1f, 7f);

        Vector3 targetPosition = target.position + offset + transform.TransformDirection(Vector3.back) * distanceFromTarget;
        
        transform.position = targetPosition;
        //transform.position = new Vector3(0f,3f,0f);

        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0f);
        transform.rotation = rotation;
    }
}
