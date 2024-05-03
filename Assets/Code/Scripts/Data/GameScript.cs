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

    public string GetNextSceneCategory()
    {
        return GetScene(sceneIndex + 1).GetCategory();
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

    public void NextScene()
    {
        sceneIndex++;
        messageIndex = 0;
        if (scenes[sceneIndex].part != null)
        {
            idPart = scenes[sceneIndex].part;
        }
    }


    public Order GetOrder()
    {
        if (GetSceneCategory() == "order")
        {
            Requirement[] tmpreq = GetScene(sceneIndex).requirements;
            Condition[] tmpcon = GetScene(sceneIndex).conditions;
            int tmpday = GetScene(sceneIndex - 1).day;
            int tmpfail = GetScene(sceneIndex).failure;
            int tmpgood = GetScene(sceneIndex).good;
            int tmpbest = GetScene(sceneIndex).best;
            return new Order(tmpreq, tmpcon, tmpday, tmpfail, tmpgood, tmpbest);
        }
        else
        {
            return null;
        }
    }


    public void SetScriptValues(int sindex, int mindex, int day, int part)
    {
        sceneIndex = sindex;
        messageIndex = mindex;
        idDay = day;
        idPart = part;
    }

    public int FindSceneIndex(int day, int part)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i].category == "dialogue" && scenes[i].day == day && scenes[i].part == part)
            {
                return i;
            }
        }
        return -1;
    }

}
