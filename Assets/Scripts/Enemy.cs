using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    private ViewingCamera Camera;
    public float PlayerDet;
    public int DamidgePlayer = 5;
    public bool DamidgingHappen = false;
    public int timeRemaining;
    public bool Agro = false;



    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            Debug.Log(timeRemaining);
        }

        Debug.Log("Time's up!");
        agro = true;
    }

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
            if (Camera.IsCrouched == true)
            {
                Debug.Log("Time to find longer");
                StartTimer(5);
            }
            else
            {
                Debug.Log("time to find base speed");
                StartTimer(25);
            }

        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

        PlayerDet = PlayerScript.DetectSpeed;
    }

    public void StartTimer(int timeWanted)
    {
        timeRemaining = timeWanted;
        StartCoroutine(Countdown());
    }

}
