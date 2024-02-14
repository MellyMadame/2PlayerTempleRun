using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject Player;

    private bool methodAvailable = true;
    private float methodRestrictionTimer = 0f;
    private float methodRestrictionDuration = 3f; // Default restriction duration

    void Update()
    {
        if (!methodAvailable)
        {
            methodRestrictionTimer -= Time.deltaTime;

            if (methodRestrictionTimer <= 0)
            {
                methodAvailable = true;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.L))
            {
                SpawnPrefabRight();
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                SpawnPrefabLeft();
            }
        }
    }

    private void SpawnPrefabLeft()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(-3.2f, Player.transform.position.y, Player.transform.position.z - 2.2f), Quaternion.identity);
        methodAvailable = false;
        methodRestrictionTimer = methodRestrictionDuration;
    }

    private void SpawnPrefabRight()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(0.0f, Player.transform.position.y, Player.transform.position.z - 2.1f), Quaternion.identity);
        methodAvailable = false;
        methodRestrictionTimer = methodRestrictionDuration;
    }
}
