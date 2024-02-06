using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChangeDoor : MonoBehaviour
{
    public GameObject player;
    public string targetScene;
    private bool playerInInteractionArea = false;
    private InputControls input = null;

    private void Awake()
    {
        input = new InputControls();
        input.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"Door interaction zone entered by {other.name}");
        if (other.tag == "player")
        {
            playerInInteractionArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"Door interaction zone exited by {other.name}");
        if (other.tag == "player")
        {
            playerInInteractionArea = false;

        }
    }

#pragma warning disable IDE0051 // This is used by the PlayerInput component
    private void OnInteract() {
        Debug.Log("Interacting");
        if (playerInInteractionArea)
        {
            Debug.Log($"Should change scenes to {targetScene}");
            SceneManager.LoadScene(targetScene);
        }
    }
#pragma warning restore IDE0051 // This is used by the PlayerInput component
}
