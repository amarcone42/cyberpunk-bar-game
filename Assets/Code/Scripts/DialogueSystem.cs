using System;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private GameManager gameManager;

    private Boolean managerStatus = false;
    [SerializeField] TextArchitect TextArchitect;

    public TextAsset jsonFile;
    private GameScript script;

    void Start()
    {
        gameManager = GetComponent<GameManager>();

        script = JsonUtility.FromJson<GameScript>(jsonFile.text);
        TextArchitect = FindAnyObjectByType<TextArchitect>();
        
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
                if (script.HasNextMessage())
                {
                    TextArchitect.WriteMessage(script.NextMessage());
                } else
                {
                    gameManager.SwitchDialogueToDrink();
                }
                
            }
        }
    }

    public void ChangeState(Boolean state)
    {
        managerStatus = state;
    }


    public void LoadDialogueValues()
    {
        script.SetScriptValues(0, 0, 1, 1);
        if (script.GetSceneCategory() == "dialogue")
        {
            TextArchitect.WriteMessage(script.GetActiveMessage());
        } else
        {
            Debug.Log("Not a message: " + script.GetSceneCategory());
            Debug.Log(script.GetActiveScene());
        }
        
    }
}
