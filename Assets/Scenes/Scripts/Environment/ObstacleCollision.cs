
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        charModel = GameObject.Find("/Player/Ch48_nonPBR@Standard Run");
    }

    void OnTriggerEnter(Collider other)
    {
        print("Enter");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Back");
    }
}