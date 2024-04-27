using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextArchitect TextArchitect;

    public TextAsset jsonFile;
    private Script script;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        script = JsonUtility.FromJson<Script>(jsonFile.text);
        TextArchitect = FindAnyObjectByType<TextArchitect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TextArchitect.NewMessage(LoadNewMessage());
        }
        
    }

    private Message LoadNewMessage()
    {
        if (index < script.GetLength() - 1)
        {
            index++;
        }
        return script.GetMessage(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
