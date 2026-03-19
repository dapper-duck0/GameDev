using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // DECLARE ALL VARIABLES/SCRIPTS HERE!
    public float Speed = 10.0f;
    public float RotationSpeed = 100.0f;
    public float DetectSpeed = 10.0f;
    public int health = 100;
    public bool stealth = false;

    // Mouse sensitivity
    public float MouseSen;

    // Input System
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction stealthAction;
    private InputAction unlockMouseAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        // Grab actions by name (must match your Input Action Asset)
        moveAction      = playerInput.actions["Move"];
        lookAction      = playerInput.actions["Look"];
        stealthAction   = playerInput.actions["Crouch"];
        unlockMouseAction = playerInput.actions["UnlockMouse"];
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // --- Mouse Look ---
        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float mouseX = lookInput.x * MouseSen * Time.deltaTime;

        // --- Movement ---
        Vector3 moveInput = moveAction.ReadValue<Vector3>();
        float translation = -moveInput.y * Speed * Time.deltaTime;
        float strafe = -moveInput.x * Speed * Time.deltaTime;

        // Move along z-axis, rotate around y-axis
        transform.Translate(strafe, 0, translation);
        transform.Rotate(0, mouseX, 0);

        // --- Unlock mouse ---
        if (unlockMouseAction.WasPressedThisFrame() && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // --- Death check ---
        if (health == 0)
        {
            // SceneManager.LoadScene("GameOver");
            Debug.Log("you died");
        }
    }

    void LateUpdate()
    {
        // Stealth toggle based on Left Ctrl held
        if (stealthAction.IsPressed())
        {
            stealth = true;
            Speed = 10.0f / 1.5f;   // avoid stacking divisions each frame
        }
        else
        {
            stealth = false;
            Speed = 10.0f;
        }
    }
}