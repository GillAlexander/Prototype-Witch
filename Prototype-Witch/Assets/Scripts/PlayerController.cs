using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private LayerMask layerMask = default;
    private RaycastHit rayHit = default;
    private Vector3 direction = Vector3.zero;

    private void Start()
    {
        layerMask = 8;
    }

    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
        //    {
        //        transform.LookAt(rayHit.point);
        //    }
        //}
        //direction = transform.position + Vector3.forward;

        Quaternion newRotation = Quaternion.Euler(0,0,0);

        if (Input.GetKey(KeyCode.W))
        {
            newRotation = Quaternion.Euler(-1 * Time.deltaTime * 50, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            newRotation = Quaternion.Euler(0, 1 * Time.deltaTime * 50, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newRotation = Quaternion.Euler(0, -1 * Time.deltaTime * 50, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newRotation = Quaternion.Euler(1 * Time.deltaTime * 50, 0, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1));
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.Euler(new Vector3(0, 0, -1));
        }

        transform.rotation *= newRotation;

        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}