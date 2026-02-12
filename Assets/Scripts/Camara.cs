using UnityEngine;

public class Camara : MonoBehaviour
{
    public float offset= 0.1f;
    public float normal = 0.8f;
    public bool IsCrouched = false;
    void Start ()
    {
    
        
    }
  
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsCrouched = false)
        {
            transform.Translate(0, normal-offset, 0);
        }
        else if (IsCrouched = true && Input.GetKeyDown(KeyCode.LeftControl) = false)
        {
            transform.Translate(0, -normal, 0);
        }
    }
}