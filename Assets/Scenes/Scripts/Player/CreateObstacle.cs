using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject Player;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            SpawnPrefabLeft();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            SpawnPrefabRight();
        }
    }

    private void SpawnPrefabRight()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(-2.2f, Player.transform.position.y, Player.transform.position.z - 2.2f), Quaternion.identity);
    }

    private void SpawnPrefabLeft()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(2.2f, Player.transform.position.y, Player.transform.position.z - 2.1f), Quaternion.identity);
    }
}
