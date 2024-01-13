using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Collider1 : MonoBehaviour
{
    public int player2Lives = 3; // Initial number of lives

    public GameObject thePlayer;
    public GameObject charModel;

    private void Start()
    {
        thePlayer = GameObject.Find("Player2");
        charModel = GameObject.Find("/Player2/Ch48_nonPBR@Standard Run");
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with an object tagged as "LifePickup"
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
            // Increment the player's lives
            player2Lives--;

            // Destroy the life pickup object (adjust as needed)
            //Destroy(collision.gameObject);

            HideHearts();
            if (player2Lives == 0)
            {
                thePlayer.GetComponent<PlayerMove>().enabled = false;
                charModel.GetComponent<Animator>().Play("Stumble Back");
            }
        //}
        // You can add more collision checks for other scenarios (e.g., colliding with enemies, hazards, etc.)
    }

    private void HideHearts()
    {
         if (player2Lives == 2)
        {
            GameObject.Find("/Canvas/Heart3Player2").SetActive(false);
        }
        if (player2Lives == 1)
        {
            GameObject.Find("/Canvas/Heart2Player2").SetActive(false);
        }
        if (player2Lives == 0)
        {
            GameObject.Find("/Canvas/Heart1Player2").SetActive(false);
        }
    }
}
