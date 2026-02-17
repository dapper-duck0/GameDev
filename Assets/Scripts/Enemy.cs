using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    public float PlayerDet;
    public int DamidgePlayer = 5;
    public bool DamidgingHappen = false;
    public bool EnemySight = true;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
    }
    public float hitRadiusDistance = 10f;

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerDet = PlayerScript.DetectSpeed;  
        if (EnemySight) {//detects collistion [to do]
            PlayerScript.heath = heath - DamidgePlayer;
            Debug(PlayerScript.heath);
            DamidgingHappen = true;
        }
        else{
            DamidgingHappen = false;
        }
    }
}
