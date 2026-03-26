using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Player PlayerScript;
    private ViewingCamera Camera;
    public GameObject playerObj;

    public float PlayerDet;
    public float hitRadiusDistance = 10f;
    public float radius = 1.0f;
    public float maxDistance = 10.0f;

    public LayerMask layerMask;

    public int DamagePlayer = 5;
    public int TimerAddTime;
    public int maxTime;
    
    public bool DamageHappen = false;
    public bool Agro = false;
    public bool StopTimer = false;
    public bool timerRunning = false;
    private bool playerDetected = false;

    // The timer
    IEnumerator Countdown(int timeRemaining)
    {
        Debug.Log("Timer started");
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

    // To start a timer
    public void StartTimer(int timeWanted)
    {
        if (!timerRunning)
        {
            timerRunning = true;
            StartCoroutine(Countdown(timeWanted));
        }
    }

    void Start()
    {
        // Find player if not assigned in Inspector
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        // Get the ViewingCamera script from the scene
        Camera = FindObjectOfType<ViewingCamera>();

        // Get PlayerScript from the player object
        if (playerObj != null)
            PlayerScript = playerObj.GetComponent<Player>();

        Debug.Log("The script is being accessed. Player: " + playerObj);
    }

    void Update()
    {
        RayCastingSphere();

        if (Agro == true)
        {
            DamageHappen = true;
            Debug.Log("Player is dying");

            // Move enemy toward the player
            if (playerObj != null)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    playerObj.transform.position,
                    4.5f * Time.deltaTime
                );
            }

            Debug.Log("Moving enemy towards player.");
        }
    }

    // Creates a SphereCast to detect the player
    void RayCastingSphere()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, radius, transform.forward, out hit, maxDistance, layerMask))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.blue);

            if (hit.collider.CompareTag("Player"))
            {
                transform.LookAt(hit.collider.transform);

                // Only start the timer once
                if (!playerDetected && !timerRunning && !Agro)
                {
                    playerDetected = true;

                    if (Camera != null && Camera.IsCrouched)
                    {
                        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);
                        StartTimer(25);
                        Debug.Log("Player found crouched.");
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.purple);
                        StartTimer(15);
                        Debug.Log("Player found uncrouched.");
                    }
                }
            }
        }
        else
        {
            // Player left detection range, reset detection
            playerDetected = false;
        }
    }
}