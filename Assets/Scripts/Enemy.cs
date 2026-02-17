using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    public float PlayerDet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
        PlayerDet = PlayerScript.DetectSpeed;  
        Debug.Log("PlayerDet");
    }
    public float hitRadiusDistance = 10f;

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
