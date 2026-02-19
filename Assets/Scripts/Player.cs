using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.PhysicsModule;
public class Player : MonoBehaviour
{
    //DECLARE ALL VERIABLES/SCRIPTS HERE!
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public float DetectSpeed = 10.0f;
    public int heath = 100;
    Ray MarkEnemy;
    RaycastHit EnemyTag;
    public bool stealth = false;


    void Update()
    {
        // movement based on the axis of input instead of keys
        float translation = -Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * RotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
        if (heath == 0)
        {
            //loadscene("GameOver");
            Debug.Log("you died");
        }
    }
    void LateUpdate()
    {


        // Checks if shift keys are down, if so turns stealth to true, if not stealth is set to false.
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            stealth = true;
            Speed = Speed / 1.5f;
        }
        else
        {
            stealth = false;
            Speed = 10.0f;
        }
        //raycast shinanigans
        if (Input.GetKeyDown("Q")) {
            MarkEnemy = new Ray(transform.position, transform.forward);         
            if(Physics.Raycast(MarkEnemy, out EnemyTag))
            {
                Debug.Log(EnemyTag.collider + "was hit"); 
                //if(MarkEnemy)
                //{ 	
                    
                //} 
            } 

        }
    }
}

