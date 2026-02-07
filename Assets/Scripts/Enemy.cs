using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player PlayerScript;
    public float PlayerDet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //          
        //the line below is having issues
        PlayerDet = PlayerScript.DetectSpeed;  
        Debug.Log(PlayerDet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
