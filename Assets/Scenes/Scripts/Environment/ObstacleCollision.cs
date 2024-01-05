
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{

    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        //print("Enter");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
}