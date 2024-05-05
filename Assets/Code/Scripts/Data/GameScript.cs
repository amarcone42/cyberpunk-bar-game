using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
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
    public SceneBlock GetNextScene()
    {
        if (sceneIndex + 1 < scenes.Length)
        {
            return scenes[sceneIndex + 1];
        }
        else
        {
            return null;
        }
    }
    public int GetNextSceneDay()
    {
        if (sceneIndex + 1 < scenes.Length)
        {
            return scenes[sceneIndex + 1].day;
        } else
        {
            return -1;
        }
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
        return messageIndex < GetActiveScene().GetMessagesNumber() - 1;
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
        if (scenes[sceneIndex].part > 0)
        {
            idPart = scenes[sceneIndex].part;
        }
        if (scenes[sceneIndex].day > 0)
        {
            idDay = scenes[sceneIndex].day;
        }
    }

    public Boolean CheckNewDay()
    {
        if (GetNextSceneCategory() == "dialogue")
        {
            if (scenes[sceneIndex].day < scenes[sceneIndex + 1].day)
            {
                return true;
            }
        }
        return false;
    }

    public Boolean CheckEnding()
    {
        if (sceneIndex + 1 < scenes.Length)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public Order GetOrder()
    {
        if (GetSceneCategory() == "order")
        {
            string tmpdescription = GetScene(sceneIndex).description;
            Requirement[] tmpreq = GetScene(sceneIndex).requirements;
            Condition[] tmpcon = GetScene(sceneIndex).conditions;
            int tmpday = GetScene(sceneIndex - 1).day;
            int tmpfail = GetScene(sceneIndex).failure;
            int tmpgood = GetScene(sceneIndex).good;
            int tmpbest = GetScene(sceneIndex).best;
            return new Order(tmpdescription, tmpreq, tmpcon, tmpday, tmpfail, tmpgood, tmpbest);
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
