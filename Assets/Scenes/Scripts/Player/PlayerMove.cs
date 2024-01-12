using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;

    // Die Geschwindigkeit, in der nach rechts oder links gelaufen wird
    public float leftRightSpeed = 4;
    //es muss überprüft werden, ob der Spieler sich bewegen kann. Für den Start des Spiels (Tutorial 12)
    static public bool canMove = false;
    private bool isOnLeftSide = true; // Starting on the left side

    public bool isJumping = false;
    public bool comingDown = false;

    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {

        //Vector 3 = z-Achse, 
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {

            if (isOnLeftSide && Input.GetKey(KeyCode.RightArrow))
            {
                SwitchSide();
                // Moves an object up 2 units
                transform.position += new Vector3(4, 0, 0);
            }
            if (!isOnLeftSide && Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-4, 0, 0);
                SwitchSide();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jumping Up");
                    StartCoroutine(JumpSequence());
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
    }
    void SwitchSide()
    {
        isOnLeftSide = !isOnLeftSide;
    }

    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");

    }

}
