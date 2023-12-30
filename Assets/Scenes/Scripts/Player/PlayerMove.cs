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
   
    // Update is called once per frame
    void Update()
    {
        //Vector 3 = z-Achse, 
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true){
            if (Input.GetKey(KeyCode.LeftArrow)) { 
            if(this.gameObject.transform.position.x > LevelBoundary.leftSide) 
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
             if (Input.GetKey(KeyCode.RightArrow)) {  
            // die Minus 1 zum Schluss invertiert die Bewegung nach links. Somit geht der Spieler nach rechts. 
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
             }
        }
    
    }
}
