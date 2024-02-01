using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLineScriptableObject : ScriptableObject
{

    public string characterName;

    public Sprite sprite;

    public string dialogue;

    public Action<GameObject> action;

    public DialogueLineScriptableObject(string characterName, string dialogue)
    {
        this.characterName = characterName;
        this.dialogue = dialogue;
    }

}
