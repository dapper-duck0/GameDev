using UnityEngine;
using UnityEngine.SceneMangement;

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
        Debug.Log(PlayerDet);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var ray1 = new Ray( transform.position, transform.forward );
                    
        var hit : RaycastHit; 
                        
        if( Physics.Raycast( ray1, hit, int_HitRadiusDistance ))
        { 
            if( (hit.collider.name == "FPS") || (hit.collider.name == "Player") ) 
            { 	
                SceneManger.LoadScene("GameOverScene");
            } 
        } 
    }
}
