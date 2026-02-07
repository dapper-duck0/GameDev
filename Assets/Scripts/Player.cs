using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public float DetectSpeed = 10.0f;
    public bool stealth = false;

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * RotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        // Checks if shift keys are down, if so turns stealth to true, if not stealth is set to false.
        if (Input.GetKeyDown("Shift"))
        {
            stealth = true;
            Speed = Speed / 1.5f;
        }
        else
        {
            stealth = false;
            Speed = 10.0f;
        }

    }
}

