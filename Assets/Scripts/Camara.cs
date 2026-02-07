using UnityEngine;

public class Camara : MonoBehaviour
{
    //move to player
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    //for the steath mode
    public Player stealth;
  
    void Update ()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (stealth == true)
        {
            //will move the camara down but for now nothing
        }
    }
}