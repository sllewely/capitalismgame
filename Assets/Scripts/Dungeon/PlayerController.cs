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
            Debug.Log("move");
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
        // Attack
        if (Input.GetKeyDown(KeyCode.J)) {
            weaponAnimator.Play("Base Layer.Attack1");
        }

        // Rotation
        var targetAngle = Mathf.Atan2(directionInput.x, directionInput.y) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        
        // Move
        characterController.Move(speed * new Vector3(moveInput.x, 0.0f, moveInput.y) * Time.deltaTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveInput = Vector2.zero;
    }
}
