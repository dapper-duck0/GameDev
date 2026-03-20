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
    public float radius = 1.0f;
    public float maxDistance = 10.0f;

    public LayerMask layerMask;

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

    // put raycase sphere here


    void Start()
    {
        Debug.Log("The script is being accessed" + playerObj);
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //PlayerScript = playerObj.GetComponent<Player>();
        //testing to see if PlayerDet is getting grabed 
        //transform.LookAt(playerObj.transform);
        
    }

    void LateUpdate()
    {
        //transform.Translate(Vector3.forward * 4.5f * Time.deltaTime);
        //PlayerDet = PlayerScript.DetectSpeed;
        RayCastingSphere();
    }

    // creates a raycast sphere to detects the player and target them.
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

                if (Camera.IsCrouched == true)
                {
                    Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.red);
                    StartTimer(25);
                    Debug.Log("Player is found in the crouched position");
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.purple);
                    StartTimer(15);
                    Debug.Log("Player is found in the UnCrouched position");
                }
                
                //player damidge system | will make better
                if (Agro == true)
                {
                    
                    DamidgingHappen = true;
                    Debug.Log("player is dying");
                
                    transform.Translate(Vector3.forward * 4.5f * Time.deltaTime);  //should move enemy towards player if entire script works right...
                    Debug.Log("move enemy towords player.");
                }
            }
        }
    }
}
