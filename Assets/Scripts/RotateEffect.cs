using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    public Vector3 rotation;
    public bool random = true;
    
    void Start() {
        if (random) {
            rotation = new Vector3(Random.Range(-90,90), Random.Range(-90, 90), Random.Range(-90, 90));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime, Space.Self);
    }
}
