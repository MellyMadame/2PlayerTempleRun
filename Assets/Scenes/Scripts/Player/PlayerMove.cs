using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;

    //es muss überprüft werden, ob der Spieler sich bewegen kann. Für den Start des Spiels (Tutorial 12)
    static public bool canMove = false;
    
    public bool isJumping = false;
    public bool comingDown = false;
    
     public GameObject prefabToSpawn;
    public GameObject Player;
     public bool isDucking = false;
    public bool standUp = false;
    public bool crouch = false;

    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true){

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
            SpawnPrefabRight();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
             {
            SpawnPrefabLeft();
            }
            if(Input.GetKey(KeyCode.UpArrow)){
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jumping Up");
                    StartCoroutine(JumpSequence());
                }
            }
      
        if(Input.GetKey(KeyCode.DownArrow)){
            print("KeyDown");
                if(isDucking == false){
                    print("isducking ist false");
                isDucking = true;
                playerObject.GetComponent<Animator>().Play("Running Slide(2)");
                StartCoroutine(duckSequence());
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
        if(isDucking == true){
            if(standUp == false){
            transform.Translate(Vector3.down * Time.deltaTime * -3, Space.World);
            }
            if(standUp == true){
                transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
            }
        }
        
    }
    }
        //Vector 3 = z-Achse, 
     
    void SpawnPrefabLeft()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(-3.2f, Player.transform.position.y, Player.transform.position.z - 2f), Quaternion.identity);
    }

    void SpawnPrefabRight()
    {
        GameObject spawnedObject = Instantiate(prefabToSpawn, new Vector3(0.0f, Player.transform.position.y, Player.transform.position.z - 2f), Quaternion.identity);
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
        isDucking = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
    }
    
}
}
