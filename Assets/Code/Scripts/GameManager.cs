using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueSystem dialogueManager;
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] Canvas menuCanvas;
    void Start()
    {
        dialogueManager = GetComponent<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        ShowDialogueView();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public Camera mainMenuCamera;
    public Camera dialogueCamera;

    public void ShowMenuView()
    {
        dialogueCamera.enabled = false;
        mainMenuCamera.enabled = true;
    }

    public void ShowDialogueView()
    {
        dialogueManager.ChangeState(true);

        dialogueCamera.enabled = true;
        mainMenuCamera.enabled = false;

        dialogueCanvas.enable();
        menuCanvas.disable();

        dialogueCamera.tag = "MainCamera";
        mainMenuCamera.tag = null;
    }
}
