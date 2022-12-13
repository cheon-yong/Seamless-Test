using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager
{
    private static WorldManager _world;

    public HashSet<string> mapSet = new HashSet<string>();

    int[] dirX = new int[9] {0, 0,0,-1,1,-1,1,-1,1 };
    int[] dirY = new int[9] {0, 1,-1,0,0,1,1,-1,-1 };

    public static WorldManager World
    {
        get
        {
            if (null == _world)
            {
                _world = new WorldManager();
            }

            return _world;
        }
    }
    public void AddMap(int x, int y)
    {
        string mapName = $"{x}_{y}";
        if (mapSet.Contains(mapName))
            return;

        mapSet.Add(mapName);
    }
    public void InstanceMap(int x, int y)
    {
        string mapName = $"{x}_{y}";
        if (SceneManager.GetSceneByName(mapName) == null)
        {
            Debug.Log("씬 없음");
            return;
        }

        
        if (mapSet.Contains(mapName))
        {
            Debug.Log($"{mapName} 이미 있음");
            return;
        }

        mapSet.Add(mapName);
        Debug.Log(mapSet.Count);
        SceneManager.LoadScene(mapName, LoadSceneMode.Additive);
    }

    public void LoadMap(int x, int y)
    {
        HashSet<string> loadedMap = new HashSet<string>();

        for (int i = 0; i < 9; i++)
        {
            string mapName = $"{x + dirX[i]}_{y + dirY[i]}";
            loadedMap.Add(mapName);
            InstanceMap(x + dirX[i], y + dirY[i]);
        }


        HashSet<string> beforeMap = new HashSet<string>(mapSet);
        foreach (string map in beforeMap)
        {
            if (!loadedMap.Contains(map))
            {
                mapSet.Remove(map);
                SceneManager.UnloadSceneAsync(map);
            }
        }
        

    }
}
