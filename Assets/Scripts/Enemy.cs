using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    private ViewingCamera Camera;

    public float PlayerDet;
    public float hitRadiusDistance = 10f;

    public int DamidgePlayer = 5;
    public int TimerAddTime;
    public int maxTime;

    public bool DamidgingHappen = false;
    public bool Agro = false;
    public bool StopTimer = false;

    //the timer
    IEnumerator Countdown(int timeRemaining)
    {
        maxTime = timeRemaining;
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            Debug.Log(timeRemaining);

            if (StopTimer == true or timeRemaining > maxTime)
            {
                break;
            }
            if (TimerAddTime > 0){
                timeRemaining += TimerAddTime;
            }

        }

        Debug.Log("Time's up!");
        Agro = true;
    }

    //to start a timer
    public void StartTimer(int timeWanted)
    {
        timeRemaining = timeWanted;
        StartCoroutine(Countdown());
    }

    private void OnTriggerEnter(Collider other) // needs to add a collider box around enemy that is trigger.
    {  // detects if the player is inside a collistion box and if so starts a timer to start agro mode.
        if (other.CompareTag("Player"))
        {
            StopTimer = false;
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
    
    private void OnTriggerExit(Collider others)
    {
        if (others.CompareTag("Player"))
        {
            Debug.Log("Player exited enemy sights");
            StopTimer = true;
        }
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
    }

    void LateUpdate()
    {
        PlayerDet = PlayerScript.DetectSpeed;
        if (Agro == true)
        {
            DamidgingHappen = true;
            Debug.Log("player is dying")
        }
    }
}