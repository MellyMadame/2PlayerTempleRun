using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public int playerLives = 3; // Initial number of lives

    public GameObject thePlayer;
    public GameObject charModel;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        charModel = GameObject.Find("/Player/Ch48_nonPBR@Standard Run");
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with an object tagged as "LifePickup"
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
            print("Enter");
            // Increment the player's lives
            playerLives--;

            // Destroy the life pickup object (adjust as needed)
            //Destroy(collision.gameObject);

            HideHearts();
            if (playerLives == 0)
            {
                thePlayer.GetComponent<PlayerMove>().enabled = false;
                charModel.GetComponent<Animator>().Play("Stumble Back");
            }
        //}
        // You can add more collision checks for other scenarios (e.g., colliding with enemies, hazards, etc.)
    }

    private void HideHearts()
    {
        if (playerLives == 2)
        {
            GameObject.Find("/Canvas/Heart3").SetActive(false);
        }
        if (playerLives == 1)
        {
            GameObject.Find("/Canvas/Heart2").SetActive(false);
        }
        if (playerLives == 0)
        {
            GameObject.Find("/Canvas/Heart1").SetActive(false);
        }
    }
}
