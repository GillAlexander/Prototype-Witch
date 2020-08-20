using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject objectToFollow = null;


    void Update()
    {
        var position = objectToFollow.transform.position;
        transform.position = new Vector3(position.x, position.y + 3, position.z - 8f);
        transform.LookAt(objectToFollow.transform);
    }
}
