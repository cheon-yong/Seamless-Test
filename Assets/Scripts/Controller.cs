using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float Speed = 10.0f;
    float h, v;

    public int x = 2;
    public int y = 2;
    void Start()
    {
        WorldManager.World.mapSet.Add("2_2");
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // ������
        v = Input.GetAxis("Vertical");          // ������

        // Point 2.
        transform.position += new Vector3(h, 0, v) * Speed * Time.deltaTime;
    }
}
