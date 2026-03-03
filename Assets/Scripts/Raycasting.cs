using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.PhysicsModule;
public class Raycasting : MonoBehaviour
{
    public float DetectSpeed = 10.0f;
    private RaycastHit EnemyTag;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed - firing ray"); // confirm input is working

            Ray MarkEnemy = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(MarkEnemy, out EnemyTag))
            {
                Debug.Log(EnemyTag.collider.gameObject.name + " was hit");
            }
            else
            {
                Debug.Log("Ray fired but nothing was hit");
            }
        }
    }
}
