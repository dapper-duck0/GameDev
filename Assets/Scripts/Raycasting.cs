using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.PhysicsModule;
publci class Raycasting : MonoBehaviour
{
    public float DetectSpeed = 10.0f;
    Ray MarkEnemy;
    RaycastHit EnemyTag;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            MarkEnemy = new ViewingCamera.Main.screenPointToRcay(transform.position, transform.forward);         
            if(Physics.Raycast(MarkEnemy, out EnemyTag))
            {
                Debug.Log(EnemyTag.collider.GameObject.name + " was hit"); 
                //if(MarkEnemy)
                //{ 	
                    
                //} 
            }
        }
    }
}