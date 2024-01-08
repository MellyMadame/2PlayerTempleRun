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

    public bool isDucking = false;
    public bool standUp = false;
    public bool comingDown = false;
    public bool crouch = false; // gehört zum crouch code
     Vector3 defaultScale;
    
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
         bool jumpInput = Input.GetButtonDown("Jump");

        //Vector 3 = z-Achse, 
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true){

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
        
            if(Input.GetKey(KeyCode.UpArrow)){
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jumping Up");
                    StartCoroutine(JumpSequence());
                }
            }
          /*  if(Input.GetKey(KeyCode.DownArrow)){
                if(isDucking == false){
                isDucking = true;
                playerObject.GetComponent<Animator>().Play("ducken");
                StartCoroutine(duckSequence());
                }
            }*/
              crouch = Input.GetKey(KeyCode.S);
        if (crouch)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.4f, defaultScale.z), Time.deltaTime * 7);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
        } //nur das gehört zum crouch code. Funktioniert aber leider nicht...
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
        /*
        if(isDucking == true){
            if(standUp == false){
            transform.Translate(Vector3.down * Time.deltaTime * -3, Space.World);
            }
            if(standUp == true){
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            }
        }*/
      

        }
    
     void SwitchSide() {
        isOnLeftSide = !isOnLeftSide;
    }
    
    IEnumerator JumpSequence(){
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");

    }
    IEnumerator duckSequence(){
        yield return new WaitForSeconds(0.6f);
        standUp = true;
         yield return new WaitForSeconds(0.6f);
        isDucking = false;
        standUp = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
    
}
