using UnityEngine;

public class Camara : MonoBehaviour
{
    //move to player
    public Transform PlayerPos;
    public float smoothSpeed = 0.125f;
    public float offset = 2.5f;

    //for the steath mode
    public Player stealth;
  
    void Update ()
    {
        Vector3 desiredPosition = PlayerPos.position;
        

        if (stealth == true)
        {
            //will move the camara down but for now nothing
            desiredPosition.y -= offset;
        }
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}