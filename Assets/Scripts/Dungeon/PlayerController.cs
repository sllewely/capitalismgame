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
        Debug.Log(x_axis);
        Debug.Log(y_axis);

        if (Mathf.Abs(x_axis) > Mathf.Abs(y_axis))
        {
            if (x_axis > 0.0)
            {
                transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            }
            else if (x_axis < 0.0)
            {
                transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
            }
        }
        else if (Mathf.Abs(y_axis) > Mathf.Abs(x_axis))
        {
            if (y_axis > 0.0)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else if (y_axis < 0.0)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
        }
        characterController.Move(new Vector3(x_axis, 0.0f, y_axis));
    }
}
