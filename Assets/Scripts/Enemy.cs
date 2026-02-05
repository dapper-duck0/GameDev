using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float PlayerDet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //          
        //the line below is having issues
        //PlayerDet = Player.DetectSpeed;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
