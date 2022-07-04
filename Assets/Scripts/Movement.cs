using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedOfTheGun = 10f;
    private float playerMovement;
    public InputActionAsset Map;
    InputActionMap gameplay;
    InputAction playerHorizontalInput;
    // Start is called before the first frame update
    void Awake()
    {
        gameplay = Map.FindActionMap("Player");
        playerHorizontalInput = gameplay.FindAction("Movement");

        playerHorizontalInput.performed += HorizontalInput;
        playerHorizontalInput.canceled += HorizontalInputCancel;
    }
    private void HorizontalInput(InputAction.CallbackContext obj)
    {
        playerMovement = obj.ReadValue<float>();
        Debug.Log("Player Movement performed= " + playerMovement);
    }
    private void HorizontalInputCancel(InputAction.CallbackContext obj)
    {
        playerMovement = 0;
        Debug.Log("Player Movement canceled= " + playerMovement);
    }
    private void OnEnable()
    {
        playerHorizontalInput.Enable();
    }
    private void OnDisable()
    {
        playerHorizontalInput.Disable();
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
        rotate = playerMovement * Time.deltaTime;
        move = -speedOfTheGun * Time.deltaTime;
        transform.Translate(0, rotate, move);
    }
}
