using System;
using UnityEngine;

[System.Serializable]
public class Message {
    [SerializeField] string speaker;
    [SerializeField] string text;

    public string GetSpeaker() { return speaker; }
    public string GetText() { return text; }
}
