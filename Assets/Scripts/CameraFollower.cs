using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // actually moves the camera
        transform.position = player.transform.position + .1f * offset;
    }
}
