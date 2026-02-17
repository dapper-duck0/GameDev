using UnityEngine;

public class ViewingCamera : MonoBehaviour
{
    private float offset= 0.1f;
    private float normal = 0.8f;
    public bool IsCrouched = false;
    // variables


  
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsCrouched == false) //checks if crouched and changes hieght if so.
        {
            transform.Translate(0, -(normal-offset), 0);
        }
        else if (IsCrouched == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.Translate(0, offset, 0);
        }
    }
}
