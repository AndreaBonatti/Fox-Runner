using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    public GameObject ramp;

    private Transform playerTransform;
    private float spawnZ = -18.0f;
    private float tileLenght = 6.0f;
    private int amountOfTilesOnScreen = 7;
    private float safeZone = 30.0f;

    private List<GameObject> activeTiles;

    private int lastPrefabIndex = 0;

    private void Start()
    {
        // During the levels the cursor is invisible
        Cursor.visible = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        // At the begginin of the level i spawn the ramp where the ball is located and the first 7 parts of the bridge
        spawnRamp();
        for (int i = 0; i < amountOfTilesOnScreen; i++)
        {
            // The tile is a single part of the bridge
            spawnTile(0);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            spawnLevel(90, 0, 2);
        }
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            spawnLevel(140, 0, 4);
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            spawnLevel(190, 0, 7);
        }
    }
    
    private void spawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilesPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilesPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLenght;
        activeTiles.Add(go);
    }

    private void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilesPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilesPrefabs.Length);
        }
        return randomIndex;
    }

    private void spawnRamp()
    {
        GameObject go = Instantiate(ramp) as GameObject;
        go.transform.SetParent(transform);
        activeTiles.Add(go);
    }

    // This function create and destroy the tile of the level during the game
    private void spawnLevel(float nearFinishLine, int minNum, int maxNum)
    {
        if (spawnZ <= nearFinishLine)
        {
            if (playerTransform.position.z - safeZone > (spawnZ - amountOfTilesOnScreen * tileLenght))
            {
                spawnTile(Random.Range(minNum, maxNum));
                deleteTile();
            }
        }
        else
        {
            spawnTile(0);
        }
    }
}
