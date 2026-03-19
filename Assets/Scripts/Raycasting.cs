using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Raycasting : MonoBehaviour
{
    public float RayDistance = 100f;
    private RaycastHit EnemyTag;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray MarkEnemy = new Ray(transform.position, -transform.forward);

            // Draws the ray in the Scene view (visible for 2 seconds)
            Debug.DrawRay(transform.position, -transform.forward * RayDistance, Color.red, 2f);

            if (Physics.Raycast(MarkEnemy, out EnemyTag, RayDistance))
            {
                Debug.Log(EnemyTag.collider.gameObject.name + " was hit");
                if (EnemyTag.collider.CompareTag("EnemyRay"))
                {
                    Debug.Log("mark the enemy");
                }
            }
            else
            {
                Debug.Log("Nothing hit - check Scene view for red ray direction");
            }
        }
    }
}