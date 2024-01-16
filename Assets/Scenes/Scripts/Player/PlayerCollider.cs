using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public int playerLives = 3; // Initial number of lives

    public GameObject thePlayer;
    public GameObject charModel;

    public AudioSource source;

    public GameObject particle;
    public float particleLifetime = 0.4f;

    public GameObject restartWindow;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        charModel = GameObject.Find("/Player/Ch48_nonPBR@Standard Run");
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 collisionPosition = other.ClosestPoint(transform.position);

        // Activate particles at the collision position
        ActivateParticles(collisionPosition);
        // Check if the player collides with an object tagged as "LifePickup"
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        source.Play();
        // Increment the player's lives
        playerLives--;

        // Destroy the life pickup object (adjust as needed)
        //Destroy(collision.gameObject);

        HideHearts();
        if (playerLives == 0)
        {
            thePlayer.GetComponent<PlayerMove>().enabled = false;
            charModel.GetComponent<Animator>().Play("Stumble Back");
            restartWindow.SetActive(true);
        }
        //}
        // You can add more collision checks for other scenarios (e.g., colliding with enemies, hazards, etc.)
    }

    private void ActivateParticles(Vector3 position)
    {
        // Instantiate the particle system at the collision position
        GameObject particleSystemInstance = Instantiate(particle, position, Quaternion.identity);

        Destroy(particleSystemInstance, particleLifetime);
    }

    private void HideHearts()
    {
        if (playerLives == 2)
        {
            GameObject.Find("/Canvas/RedHeart3").SetActive(false);
        }
        if (playerLives == 1)
        {
            GameObject.Find("/Canvas/RedHeart2").SetActive(false);
        }
        if (playerLives == 0)
        {
            GameObject.Find("/Canvas/RedHeart1").SetActive(false);
        }
    }
}
