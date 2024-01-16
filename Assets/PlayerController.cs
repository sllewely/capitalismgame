using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_axis = Input.GetAxis("Horizontal") * speed;
        float y_axis = Input.GetAxis("Vertical") * speed;
        characterController.Move(new Vector3(x_axis, 0.0f, y_axis));
    }
}
