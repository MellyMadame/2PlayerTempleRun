using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;

    //es muss überprüft werden, ob der Spieler sich bewegen kann. Für den Start des Spiels (Tutorial 12)
    static public bool canMove = false;

    public bool isJumping = false;
    public bool comingDown = false;

    public GameObject prefabToSpawn;
    public GameObject Player;

    public GameObject playerObject;

    private bool canPutObstacle = true;
    private float obstacleRestrictionTimer = 0f;
    private float obstacleRestrictionDuration = 2f; // Default restriction duration
    public Slider timerSlider; // Reference to the UI Slider/Progress Bar

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (!canPutObstacle)
        {
            obstacleRestrictionTimer -= Time.deltaTime;

            if (obstacleRestrictionTimer <= 0)
            {
                canPutObstacle = true;
            }
            // Update the UI element
            timerSlider.value = obstacleRestrictionTimer / obstacleRestrictionDuration;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                SpawnPrefabRight();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                SpawnPrefabLeft();
            }

        }

        if (canMove == true)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    //playerObject.GetComponent<Animator>().Play("Jumping Up");
                    StartCoroutine(JumpSequence());
                }
            }
        }

        // Handle jumping
        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
    }

    private void SpawnPrefabLeft()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(-3.2f, Player.transform.position.y, Player.transform.position.z - 2f), Quaternion.identity);
        canPutObstacle = false;
        obstacleRestrictionTimer = obstacleRestrictionDuration;
    }

    private void SpawnPrefabRight()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(0.0f, Player.transform.position.y, Player.transform.position.z - 2f), Quaternion.identity);
        canPutObstacle = false;
        obstacleRestrictionTimer = obstacleRestrictionDuration;
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.46f);
        comingDown = true;
        yield return new WaitForSeconds(0.48f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
}
