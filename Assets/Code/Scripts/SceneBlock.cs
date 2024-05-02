using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneBlock
{
    public string category;
    public string day;
    public string part;
    public Message[] messages;
    public Requirement[] requirements;
    public Condition[] conditions;
    public string failure;
    public string good;
    public string best;

    public Message GetMessage(int index) { return messages[index]; }

    public int GetMessagesNumber() { return messages.Length; }

    public string GetCategory() { return category; }

    
    
}
