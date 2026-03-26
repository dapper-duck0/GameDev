uning UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameScript : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction Interact;

    void Start() 
    {
        Interact = playerInput.actions["Interact"];
    }
    void Update()
    {
        LoadNextSceneByName()
    }

    public void LoadNextSceneByName()
    {
        private void OnTriggerEnter(Collider other)
        {
            // Check if the entering object has the "Player" tag
            if (other.CompareTag("Player") && Interact.IsPressed())
            {
                SceneManager.LoadScene("EndScene");
                //this should be a scene we need to create to play an end screan animation
                
            }
        }
        
        
    }
}