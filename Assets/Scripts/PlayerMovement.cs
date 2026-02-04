using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    double Speed = 20;
    double Jump = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // this is a update that happends every couple of frames rather than everyframe
    void Update()
    {
        if (Input.GetButtonDown("w"))
        {
            Debug.Log("forward");
        }
    }
}
