using UnityEngine;

public class Camara : MonoBehaviour
{
    public float offset= 0.1f;
    public float normal = 0.8f;
    void Start ()
    {
    
        
    }
  
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.Translate(0, normal-offset, 0);
        }
        else
        {
            transform.Translate(0, normal, 0);
        }
    }
}