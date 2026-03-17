using UnityEngine;

public class DamidgeBoxes : MonoBehaviour
{
    //this script litterly exits just to check if the player is inside a damidge zone 
    //for the enemy script
    public bool IsInside = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            IsInside = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            IsInside = true;
        }
    }
    private void OnTriggerExit(Collider others)
    {
        Debug.Log(others);
        if (others.CompareTag("Player"))
        {
            IsInside = false;
        }
    }

}


