using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO: FIX
    //float Speed = 20;
    //float Jump = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // this is a update that happends every couple of frames rather than everyframe
    void Update()
    {
        if (Input.GetAxis("vertical"))
        {
            Debug.Log("forward");
        }
    }
}
