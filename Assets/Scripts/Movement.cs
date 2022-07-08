using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public float speedOfTheGun = 1f;
    private float touchMovement;
    [HideInInspector] public float move = 0, rotate = 0;
    [HideInInspector] public bool aliveState = true, finisher = false, waitTouch = true;

    public InputActionAsset Map;
    InputActionMap gameplay;
    InputAction playerHorizontalTouchInput, playerHorizontalTouchSwipeInput;
    // Start is called before the first frame update
    void Awake()
    {
        gameplay = Map.FindActionMap("Player");
        playerHorizontalTouchInput = gameplay.FindAction("TouchPress");
        playerHorizontalTouchSwipeInput = gameplay.FindAction("TouchSwipe");

        playerHorizontalTouchInput.started += TouchInput;
        playerHorizontalTouchSwipeInput.performed += HorizontalTouchInput;

    }


    private void TouchInput(InputAction.CallbackContext obj)
    {
        waitTouch = false;
        slider.gameObject.SetActive(false);
    }
    private void HorizontalTouchInput(InputAction.CallbackContext obj)
    {
        touchMovement = obj.ReadValue<float>();
    }


    private void OnEnable()
    {
       
        playerHorizontalTouchInput.Enable();
        playerHorizontalTouchSwipeInput.Enable();
    }
    private void OnDisable()
    {
        
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
        if (aliveState && !waitTouch && !finisher)
        {
            move = -speedOfTheGun * Time.deltaTime;
            rotate = -(touchMovement / 10) * Time.deltaTime;
            transform.Translate(0, rotate, move);
            if (transform.position.x >= 0.655f)
                transform.position = new Vector3(0.655f, transform.position.y, transform.position.z);
            else if (transform.position.x <= -0.627f)
                transform.position = new Vector3(-0.627f, transform.position.y, transform.position.z);
            if (transform.position.z >= 86)
                transform.position = new Vector3(transform.position.x, transform.position.y, 86);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotate = 0;
        if (collision.gameObject.tag == "Finish")
        {
            
            move = 0;
            finisher = true;   
        }
    }
}
