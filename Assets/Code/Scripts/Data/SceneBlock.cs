using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneBlock
{
    public string category;
    // Attributes for dialogue scene
    public int day;
    public int part;
    public string character;
    // Attributes for order scene
    public Message[] messages;
    public string description;
    public Requirement[] requirements;
    public Condition[] conditions;
    public int failure;
    public int good;
    public int best;
    // Attributes for jump scene
    public int nextDay;
    public int nextPart;
    // The end scene only has category

    public Message GetMessage(int index) { return messages[index]; }

    public int GetMessagesNumber() { return messages.Length; }

    public string GetCategory() { return category; }

    
    
}
