using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    public  float moveSpeed = 3;

    //es muss überprüft werden, ob der Spieler sich bewegen kann. Für den Start des Spiels (Tutorial 12)
    static public bool canMove = false;
  
    public bool isOnRightSide = true; // Starting on the Right side
    
    public GameObject Player2Collider1;

    Player2Collider1 colliderScript;
    public bool isJumping = false;
    public bool comingDown = false;
    public float player2Live;
    
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
        player2Live =GameObject.Find("Player2").GetComponent<Player2Collider1>().player2Lives;
        print(player2Live);
        //Vector 3 = z-Achse, 
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        
             if (isOnRightSide && Input.GetKeyUp(KeyCode.A))
        {   
             SwitchSide();
           // Moves an object up 2 units
           transform.position += new Vector3(-4, 0, 0);
        }
        if (!isOnRightSide && Input.GetKeyUp(KeyCode.D))
        {   
            transform.position += new Vector3(4, 0, 0);
           SwitchSide();
        }
            if(Input.GetKeyUp(KeyCode.W)){
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jumping Up");
                    StartCoroutine(JumpSequence());
                }
            }
      

        // Handle jumping
        if (isJumping == true)
        {
            if(comingDown == false){
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if(comingDown == true){
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
        
    }
     void SwitchSide() {
        isOnRightSide = !isOnRightSide;
    }
    
    IEnumerator JumpSequence(){
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");

    }
    
}
