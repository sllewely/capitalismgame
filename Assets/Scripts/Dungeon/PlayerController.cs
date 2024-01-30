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
    public float gravity = -10f;

    private CharacterController characterController;
    private Animator playerAnimator;
    private GameObject player;

    private InputControls input = null;
    private Vector2 moveInput = Vector2.zero;
    private Vector3 directionInput = new Vector2(1f, 0f);

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

        player = transform.Find("Knight").gameObject;
        playerAnimator = player.GetComponent<Animator>();
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
        // Attack
        if (Input.GetKeyDown(KeyCode.J)) {
            playerAnimator.SetTrigger("Attack");
        }

        // Rotation
        var targetAngle = Mathf.Atan2(directionInput.x, directionInput.y) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        // Move
        moveInput.Normalize();
        if (moveInput.magnitude > 0)
        {
            playerAnimator.SetBool("IsRunning", true);
            characterController.Move(speed * new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime);
        } else
        {
            playerAnimator.SetBool("IsRunning", false);
        }

        // Gravity Movement
        characterController.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
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
