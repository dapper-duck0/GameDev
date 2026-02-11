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
        var ray1 = new Ray( transform.position, transform.forward ); //casts a ray for player detection
                    
        RaycastHit hit;
                        
        if( Physics.Raycast(ray1, out hit, hitRadiusDistance ))
        { 
            //what is FPS?
            if((hit.collider.name == "Player") ) //(hit.collider.name == "FPS") || //(just in case)
            { 	
                Debug.Log("hit player");
                //currently no scene named GameOverScene, but will test.
            } 
        } 
    }
}
