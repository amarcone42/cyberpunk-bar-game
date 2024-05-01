using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private Boolean managerStatus = false;
    [SerializeField] TextArchitect TextArchitect;

    public TextAsset jsonFile;
    private Script script;
    private int idDay = 1;
    private int idPart = 1;
    private int messageIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        script = JsonUtility.FromJson<Script>(jsonFile.text);
        TextArchitect = FindAnyObjectByType<TextArchitect>();
        TextArchitect.NewMessage(script.GetMessage(GetActiveDialogueId(), 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (managerStatus)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitGame();
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
        }
        return script.GetMessage(GetActiveDialogueId(), messageIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
