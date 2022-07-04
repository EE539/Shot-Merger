using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedOfTheGun = 10f;
    private float playerMovement;
    private Vector2 mouseMovement;

    public InputActionAsset Map;
    InputActionMap gameplay;
    InputAction playerHorizontalKeyboardInput, playerHorizontalMouseInput;
    // Start is called before the first frame update
    void Awake()
    {
        gameplay = Map.FindActionMap("Player");
        playerHorizontalKeyboardInput = gameplay.FindAction("Keyboard");
        playerHorizontalMouseInput = gameplay.FindAction("Mouse");

        playerHorizontalKeyboardInput.performed += HorizontalKeyboardInput;
        playerHorizontalMouseInput.performed += HorizontalMouseInput;
        playerHorizontalKeyboardInput.canceled += HorizontalInputCancel;
    }
    private void HorizontalKeyboardInput(InputAction.CallbackContext obj)
    {
        playerMovement = obj.ReadValue<float>();
        Debug.Log("Player Movement performed= " + playerMovement);
    }

    private void HorizontalMouseInput(InputAction.CallbackContext obj)
    {
        mouseMovement = obj.ReadValue<Vector2>();
    }

    private void HorizontalInputCancel(InputAction.CallbackContext obj)
    {
        playerMovement = 0;
        Debug.Log("Player Movement canceled= " + playerMovement);
    }
    private void OnEnable()
    {
        playerHorizontalKeyboardInput.Enable();
        playerHorizontalMouseInput.Enable();
    }
    private void OnDisable()
    {
        playerHorizontalKeyboardInput.Disable();
        playerHorizontalMouseInput.Disable();
    }

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
    
    //To ddo : Enable  and disable
    // Update is called once per frame
    void FixedUpdate()
    {
        float move, rotate;
        //rotate = playerMovement * Time.deltaTime;
        rotate = (-mouseMovement.x / 100) * Time.deltaTime;
        move = -speedOfTheGun * Time.deltaTime;
        transform.Translate(0, rotate, move);
    }
}
