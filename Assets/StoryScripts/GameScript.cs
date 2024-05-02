using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class GameScript
{
    public SceneBlock[] scenes;
    public int sceneIndex = 0;
    public int messageIndex = 0;
    public int idDay = 1;
    public int idPart = 1;

    public SceneBlock GetScene(int index)
    {
        return scenes[index];
    }
    public SceneBlock GetActiveScene()
    {
        return scenes[sceneIndex];
    }

    public string GetSceneCategory()
    {
        return GetActiveScene().GetCategory();
    }

    public Boolean HasNextMessage()
    {
        return messageIndex < GetScene(sceneIndex).GetMessagesNumber() - 1;
    }
    public Message GetActiveMessage()
    {
        return GetScene(sceneIndex).GetMessage(messageIndex);
    }

    public Message NextMessage()
    {
        messageIndex++;
        return GetScene(sceneIndex).GetMessage(messageIndex);
    }

    public void SetScriptValues(int sindex, int mindex, int day, int part)
    {
        sceneIndex = sindex;
        messageIndex = mindex;
        idDay = day;
        idPart = part;
    }

}
