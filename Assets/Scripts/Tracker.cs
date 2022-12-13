using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public float distance = 100.0f;
    public float height = 100.0f;

    public Transform target;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = target.position - (1 * Vector3.forward * distance) + (Vector3.up * height);
        transform.LookAt(target);
    }
}
