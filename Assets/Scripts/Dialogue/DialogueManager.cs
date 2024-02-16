using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUI;
    private InputControls input = null;

    private List<DialogueLineScriptableObject> dialogueLines;
    
    private int convoIndex = 0;

    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueText;
    
    
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
            new DialogueLineScriptableObject(characterName: "Braid Woman", "Hello!"),
            new DialogueLineScriptableObject(characterName: "Horn Woman", "Yello!"),
            new DialogueLineScriptableObject(characterName: "Braid Woman", "Jello!"),
        };

        if (characterName == null)
        {
            Debug.LogError("CharacterName text ui missing");
        }
        if (dialogueText == null)
        {
            Debug.LogError("dialogueText text ui missing");
        }

        NextDialogueLine();
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
            NextDialogueLine();
        };
    }

    public void NextDialogueLine()
    {
        if (convoIndex < dialogueLines.Count)
        {
            var dialogue = dialogueLines[convoIndex];
            SetDialogue(dialogue);
            convoIndex++;
        }
        else
        {
            // SARAH: tbh instead should disable this whole convo script
            dialogueUI.SetActive(false);
        }

        
    }
    
    void SetDialogue(DialogueLineScriptableObject dialogue)
    {
        characterName.text = dialogue.characterName;
        dialogueText.text = dialogue.dialogue;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
