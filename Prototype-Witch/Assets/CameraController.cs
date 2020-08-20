using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject objectToLookAt = null;
    [SerializeField] private float distance = 10;
    [SerializeField] private AnimationCurve animationCurve = default;
    private float currentXPos = 0f;
    private float currentYPos = 0f;
    private Vector3 position = default;
    private Quaternion newRotation = default;

    private float oldXAxisPos = 0;
    private float oldYAxisPos = 0;
    private Quaternion startRotation = default;

    private void Start()
    {
        position = new Vector3(0, 0, -distance);
        newRotation = Quaternion.Euler(currentYPos, currentXPos, 0);
        startRotation = transform.rotation;
    }

    void Update()
    {
        var xAxis = Input.GetAxis("Mouse X");
        var yAxis = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            currentXPos += oldXAxisPos + xAxis;
            currentYPos += oldXAxisPos + yAxis;

            position = new Vector3(0, 0, -distance);

            newRotation = Quaternion.Euler(currentYPos, currentXPos, 0);

            transform.rotation = newRotation;
            transform.LookAt(objectToLookAt.transform.position);

            transform.position = objectToLookAt.transform.position + newRotation * position;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, objectToLookAt.transform.position + objectToLookAt.transform.rotation * new Vector3(0, 2, -distance), Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, objectToLookAt.transform.rotation, Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1))
        {
            //oldXAxisPos = xAxis;
            //oldYAxisPos = yAxis;
        }


        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Reset camera view");
            transform.rotation = Quaternion.Euler(Vector3.zero);
            position = new Vector3(0, 0, -distance);
        }
    }
}
