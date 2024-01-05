using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;

    // Die Geschwindigkeit, in der nach rechts oder links gelaufen wird
    public float leftRightSpeed = 4;
    //es muss überprüft werden, ob der Spieler sich bewegen kann. Für den Start des Spiels (Tutorial 12)
    static public bool canMove = false;
    private bool isOnLeftSide = true; // Starting on the left side
   
    // Update is called once per frame
    void Update()
    {
        //Vector 3 = z-Achse, 
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true){

             if (isOnLeftSide && Input.GetKey(KeyCode.RightArrow))
        {
            SwitchSide();
            // Moves an object up 2 units
            transform.position += new Vector3(4, 0, 0);
        }
        else if (!isOnLeftSide && Input.GetKey(KeyCode.LeftArrow))
        {   
            transform.position += new Vector3(-4, 0, 0);
            SwitchSide();
        }
        }
    }
     void SwitchSide() {
        isOnLeftSide = !isOnLeftSide;
    }
    
}
