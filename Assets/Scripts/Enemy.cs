using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    private ViewingCamera Camera;
    private DamidgeBoxes DamidgeBoxes;

    public GameObject playerObj;

    public float PlayerDet;
    public float hitRadiusDistance = 10f;

    public int DamidgePlayer = 5;
    public int TimerAddTime;
    public int maxTime;

    public bool DamidgingHappen = false;
    public bool Agro = false;
    public bool StopTimer = false;
    public bool timerRunning = false;

    //the timer
    IEnumerator Countdown(int timeRemaining)
    {
        Debug.Log("timer started");
        maxTime = timeRemaining;

        while (timeRemaining > 0)
        {
            if (StopTimer)
            {
                timerRunning = false;
                yield break;
            }

            yield return new WaitForSeconds(1f);
            timeRemaining--;

            if (TimerAddTime > 0)
            {
                timeRemaining += TimerAddTime;
                TimerAddTime = 0;
            }

            Debug.Log(timeRemaining);
        }

        Debug.Log("Time's up!");
        Agro = true;
    }

    //to start a timer
    public void StartTimer(int timeWanted)
    {
        if (!timerRunning)
        {
            timerRunning = true;
            StartCoroutine(Countdown(timeWanted));
        }

    }

    private void OnTriggerEnter(Collider other) // needs to add a collider box around enemy that is trigger.
    {  // detects if the player is inside a collistion box and if so starts a timer to start agro mode.
        if (other.CompareTag("Player"))
        {
            StopTimer = false;
            Debug.Log("player entered the enemy sights");
            transform.LookAt(other.transform);  //turns enemy towards last player position

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
    //this should make it so that the enemy can detect player that is inside the hitbox even if they never entered it
    private void OnTriggerStay(Collider other)
    {  // detects if the player is inside a collistion box and if so starts a timer to start agro mode.
        if (other.CompareTag("Player"))
        {
            StopTimer = false;
            Debug.Log("player entered the enemy sights");
            transform.LookAt(other.transform);  //turns enemy towards last player position

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
        Debug.Log("The script is being accessed" + playerObj);
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
        transform.LookAt(playerObj.transform);
        
    }

    void LateUpdate()
    {
        transform.Translate(Vector3.forward * 4.5f * Time.deltaTime);
        Debug.Log("The script is being accessed" + playerObj + " fds");
        //PlayerDet = PlayerScript.DetectSpeed;
        if (Agro == true)
        {
            if (DamidgeBoxes.IsInside == true)
            {
                DamidgingHappen = true;
                Debug.Log("player is dying");
            }
            transform.Translate(Vector3.forward * 4.5f * Time.deltaTime);  //should move enemy towards player if entire script works right...
            Debug.Log("move enemy towords player.");
        }
    }

}