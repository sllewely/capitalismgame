using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon1WithHud : MonoBehaviour
{
    
    //Loads an intro dialogue if we haven't seen it before
    // On conversation end, go to shop.

    private List<DialogueLineScriptableObject> dialogueLines;

    void Awake()
    {
        dialogueLines = new List<DialogueLineScriptableObject>
        {
            new DialogueLineScriptableObject(characterName: "Braid Woman", "Hello!"),
            new DialogueLineScriptableObject(characterName: "Horn Woman", "Yello!"),
            new DialogueLineScriptableObject(characterName: "Braid Woman", "Jello!"),
        };
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        // Get gamedata and check state
        
        // Show dialogue if haven't yet
        DialogueManager.Instance.LoadDialogue(dialogueLines);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
