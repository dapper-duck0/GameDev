using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    private ViewingCamera Camera;
    public float PlayerDet;
    public int DamidgePlayer = 5;
    public bool DamidgingHappen = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
    }
    public float hitRadiusDistance = 10f;
    private void OnTriggerEnter(Collider other) // needs to add a collider box around enemy that is trigger.
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered the enemy sights");
            transform.LookAt(other.transform);
            if (Camera.IsCrouched == True)
            {
                Debug("Time to find longer");
            }
            else
            {
                Debug("time to find base speed");
            }
            
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

        PlayerDet = PlayerScript.DetectSpeed;  
    }
}
