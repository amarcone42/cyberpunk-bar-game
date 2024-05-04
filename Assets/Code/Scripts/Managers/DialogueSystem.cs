using System;
using System.Collections;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    private GameManager gameManager;

    private Boolean managerStatus = false;
    [SerializeField] TextArchitect TextArchitect;
    [SerializeField] ChapterScreen chapterScreen;

    public TextAsset jsonFile;
    private GameScript script;

    public AudioSourceLoop bgm;

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
                    // Show next message
                    TextArchitect.WriteMessage(script.NextMessage());
                } else if (script.GetNextSceneCategory() == "dialogue")
                {
                    // Check new day
                    if (script.CheckNewDay())
                    {
                        // Show new day
                        StartCoroutine(NewDayCoroutine());
                    }
                    // Show next scene
                    script.NextScene();
                    // Show only the active character
                    gameManager.ShowSingleCustomer(script.GetActiveScene().character);
                    TextArchitect.WriteMessage(script.GetActiveMessage());

                } else
                {
                    script.NextScene();
                    // Switch to drink mode
                    gameManager.SwitchDialogueToDrink(script.GetOrder());
                }
            }
        }
    }

    public void ChangeState(Boolean state)
    {
        managerStatus = state;
        if (managerStatus)
        {
            bgm.PlayMusic();
        }
        else
        {
            bgm.StopMusic();
        }
    }


    public void LoadDialogueValues()
    {
        script.SetScriptValues(0, 0, 1, 1);
        if (script.GetSceneCategory() == "dialogue")
        {
            // Show first day
            StartCoroutine(NewDayCoroutine(1));
            gameManager.ShowSingleCustomer(script.GetActiveScene().character);
            TextArchitect.WriteMessage(script.GetActiveMessage());
        } else
        {
            Debug.Log("Not a message: The scene category is " + script.GetSceneCategory());
        }
        
    }

    public void ChangeScene(int day, int part)
    {
        // Finds the correct scene index
        int tmpsceneindex = script.FindSceneIndex(day, part);
        // Sets dialogue parameters to the new stating point
        script.SetScriptValues(tmpsceneindex, 0,day,part);
        // Writes the first message of the new dialogue
        TextArchitect.WriteMessage(script.GetActiveMessage());
    }

    IEnumerator NewDayCoroutine()
    {
        managerStatus = false;
        chapterScreen.Show(script.GetNextSceneDay());

        yield return new WaitForSeconds(5);

        chapterScreen.Hide();
        managerStatus = true;
    }
    IEnumerator NewDayCoroutine(int day)
    {
        managerStatus = false;
        chapterScreen.Show(day);

        yield return new WaitForSeconds(5);

        chapterScreen.Hide();
        managerStatus = true;
    }
}
