using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneBlock
{
    public string category;
    public int day;
    public int part;
    public Message[] messages;
    public Requirement[] requirements;
    public Condition[] conditions;
    public int failure;
    public int good;
    public int best;

    public Message GetMessage(int index) { return messages[index]; }

    public int GetMessagesNumber() { return messages.Length; }

    public string GetCategory() { return category; }

    
    
}
