using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction Interact;

    void Start() 
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            Interact = playerInput.actions["Interact"];
        }
        else
        {
            Debug.Log("ERROR! ERROR! CANT GRAB Interact ERROR!")
        }
    }

    void Update()
    {
        // Update logic if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the "Player" tag
        if (other.CompareTag("Player") && Interact != null && Interact.IsPressed())
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}