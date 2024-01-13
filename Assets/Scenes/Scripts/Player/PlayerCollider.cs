using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public int playerLives = 3; // Initial number of lives

    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject retryWindow;

    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        charModel = GameObject.Find("/Player/Ch48_nonPBR@Standard Run");
        //retryWindow = GameObject.Find("/Canvas/RetryFenster");
    }

    void OnTriggerEnter(Collider other)
    {
        //print("Enter");
        // Increment the player's lives
        playerLives--;

        //Destroy(collision.gameObject);

        HideHearts();
        if (playerLives == 0)
        {
            EndOfGame();
        }
    }

    private void EndOfGame()
    {
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Back");
        StartCoroutine(DelayedWindowShow(2f));

        //Retry window anzeigen
    }

    IEnumerator DelayedWindowShow(float f)
    {
        yield return new WaitForSeconds(f);
        retryWindow.SetActive(true);
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
