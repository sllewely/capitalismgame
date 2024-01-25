using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    private CharacterController characterController;
    private Animator weaponAnimator;
    private GameObject weapon;

    private InputControls input = null;
    private Vector2 moveInput = Vector2.zero;
    private Vector3 directionInput = Vector2.zero;

    private float smoothTime = 0.05f;
    private float currentVelocity;


    private void Awake()
    {
        input = new InputControls();
        input.Enable();
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        weapon = transform.Find("Weapon").gameObject;
        weaponAnimator = weapon.GetComponent<Animator>();
        input.Player.Movement.performed += moving =>
        {
            moveInput = moving.ReadValue<Vector2>();
            directionInput = moving.ReadValue<Vector2>();
        };
        input.Player.Movement.started += moving =>
        {
            moveInput = moving.ReadValue<Vector2>();
        };
        input.Player.Movement.canceled += moving =>
        {
            moveInput = moving.ReadValue<Vector2>();
        };
    }

    // Update is called once per frame
    void Update()
    {
        // // Movement
        // float x_axis = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // float y_axis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //
        // if (Mathf.Abs(x_axis) > Mathf.Abs(y_axis))
        // {
        //     if (x_axis > 0.0)
        //     {
        //         transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        //     }
        //     else if (x_axis < 0.0)
        //     {
        //         transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
        //     }
        // }
        // else if (Mathf.Abs(y_axis) > Mathf.Abs(x_axis))
        // {
        //     if (y_axis > 0.0)
        //     {
        //         transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //     }
        //     else if (y_axis < 0.0)
        //     {
        //         transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        //     }
        // }
        
    
        // Attack
        if (Input.GetKeyDown(KeyCode.J)) {
            weaponAnimator.Play("Base Layer.Attack1");
        }

        var targetAngle = Mathf.Atan2(directionInput.x, directionInput.y) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        
        Debug.Log("move is " + (speed * new Vector3(moveInput.x, 0.0f, moveInput.y)));
        characterController.Move(speed * new Vector3(moveInput.x, 0.0f, moveInput.y) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    // // When game object is enabled, so is the input, else disabled.
    // private void OnEnable()
    // {
    //     input.Enable();
    //     input.Player.Movement.performed += OnMovementPerformed;
    //     input.Player.Movement.performed += OnMovementCancelled;
    // }
    //
    // private void OnDisable()
    // {
    //     input.Disable();
    //     input.Player.Movement.performed -= OnMovementPerformed;
    //     input.Player.Movement.performed -= OnMovementCancelled;
    // }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
        // Debug.Log("move value " + moveInput);
        // direction = new Vector3()
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveInput = Vector2.zero;
    }
}
