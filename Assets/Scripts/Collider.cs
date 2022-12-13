using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dir
{
    right = 0,
    left,
    down,
    up
}

public class Collider : MonoBehaviour
{
    [SerializeField]
    Dir dir;

    public MapManager map;

    
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            map.LoadMap(dir);
        }
    }

}
