using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int x;
    public int y;

    public Controller character;
    
    public void Start()
    {
        WorldManager.World.AddMap(x, y);
    }
    public void LoadMap(Dir dir)
    {
        switch (dir)
        {
            case Dir.right:
                WorldManager.World.LoadMap(x + 1, y);
                break;
            case Dir.left:
                WorldManager.World.LoadMap(x - 1, y);
                break;
            case Dir.down:
                WorldManager.World.LoadMap(x, y - 1);
                break;
            case Dir.up:
                WorldManager.World.LoadMap(x, y + 1);
                break;
        }
    }
}
