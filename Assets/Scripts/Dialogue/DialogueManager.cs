using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUI;
    private InputControls input = null;

    private List<DialogueLineScriptableObject> dialogueLines;
    
    private int convoIndex = 0;
    
    
    // Sarah: need new action scheme for conversation
    // space or enter to continue
    // need dialogue fields to be filled
    // on click, set next dialogue config
    // on click on final piece, exit dialogue
    

    private void Awake()
    {
        input = new InputControls();
        input.Enable();
        
        dialogueLines = new List<DialogueLineScriptableObject>
        {
            new DialogueLineScriptableObject(name: "Braid Woman", "Hello!"),
            new DialogueLineScriptableObject(name: "Horn Woman", "Yello!"),
            new DialogueLineScriptableObject(name: "Braid Woman", "Jello!"),
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueUI == null)
        {
            Debug.LogError("DialogueUI missing");
        }

        input.Dialogue.Continue.performed += pressed =>
        {
            // Load next Dialogue
        };

    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
