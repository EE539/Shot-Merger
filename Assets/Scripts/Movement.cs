using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedOfTheGun = 10f;
    private float playerMovement, touchMovement;
    private Vector2 mouseMovement;

    public InputActionAsset Map;
    InputActionMap gameplay;
    InputAction playerHorizontalKeyboardInput, playerHorizontalMouseInput, playerHorizontalTouchInput, playerHorizontalTouchSwipeInput;
    // Start is called before the first frame update
    void Awake()
    {
        gameplay = Map.FindActionMap("Player");
        playerHorizontalKeyboardInput = gameplay.FindAction("Keyboard");
        playerHorizontalMouseInput = gameplay.FindAction("Mouse");
        playerHorizontalTouchInput = gameplay.FindAction("TouchPress");
        playerHorizontalTouchSwipeInput = gameplay.FindAction("TouchSwipe");

        playerHorizontalKeyboardInput.performed += HorizontalKeyboardInput;
        playerHorizontalMouseInput.performed += HorizontalMouseInput;
        playerHorizontalTouchInput.started += TouchInput;
        playerHorizontalTouchSwipeInput.performed += HorizontalTouchInput;

        playerHorizontalKeyboardInput.canceled += HorizontalInputCancel;
        playerHorizontalTouchInput.canceled += TouchInputCanceled;
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

    private void TouchInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Touch Performed ");
    }
    private void HorizontalTouchInput(InputAction.CallbackContext obj)
    {
        touchMovement = obj.ReadValue<float>();
       Debug.Log("Touch movement = "+touchMovement);
    }


    private void TouchInputCanceled(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Touch finished ");
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
        playerHorizontalTouchInput.Enable();
        playerHorizontalTouchSwipeInput.Enable();
    }
    private void OnDisable()
    {
        playerHorizontalKeyboardInput.Disable();
        playerHorizontalMouseInput.Disable();
        playerHorizontalTouchInput.Disable();
        playerHorizontalTouchSwipeInput.Disable();
    }

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
    
    //To ddo : Enable  and disable
    // Update is called once per frame
    void FixedUpdate()
    {
        float move = 0, rotate = 0;
        //rotate = playerMovement * Time.deltaTime;
        //rotate = (-mouseMovement.x / 100) * Time.deltaTime;
        move = -speedOfTheGun * Time.deltaTime;
        rotate = touchMovement * Time.deltaTime;
        transform.Translate(0, rotate, move);
    }
}
