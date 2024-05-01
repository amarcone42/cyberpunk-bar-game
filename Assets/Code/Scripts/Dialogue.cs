using System;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] string id;
    [SerializeField] Message[] dialogue;
    
    public string GetId() { return id; }
    public Message GetMessage(int index)
    {
        return dialogue[index];
    }
    public int GetLength() { return dialogue.Length; }

}
