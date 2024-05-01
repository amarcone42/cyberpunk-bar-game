using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private GameManager gameManager;

    private Boolean managerStatus = false;
    [SerializeField] TextArchitect TextArchitect;

    public TextAsset jsonFile;
    private Script script;
    private int idDay = 1;
    private int idPart = 1;
    private int messageIndex = 0;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        script = JsonUtility.FromJson<Script>(jsonFile.text);
        TextArchitect = FindAnyObjectByType<TextArchitect>();
        TextArchitect.NewMessage(script.GetMessage(GetActiveDialogueId(), 0));
    }

    // DialogueSystem only use Update to get dialogue related input
    void Update()
    {
        if (managerStatus)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameManager.ReturnToMainMenu();
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                TextArchitect.NewMessage(LoadNewMessage());
            }
        }
    }

    public void ChangeState(Boolean state)
    {
        managerStatus = state;
    }

    private string GetActiveDialogueId()
    {
        return "day-" + idDay + "_part-" + idPart;
    }

    private Message LoadNewMessage()
    {
        if (messageIndex < script.GetLength(GetActiveDialogueId()) - 1)
        {
            messageIndex++;
        } else
        {
            gameManager.SwitchDialogueToDrink();
        }
        return script.GetMessage(GetActiveDialogueId(), messageIndex);
    }
}
