using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueSystem dialogueManager;
    [SerializeField] CCanvas menuCanvas;
    [SerializeField] CCanvas dialogueCanvas;
    [SerializeField] CCanvas drinkCanvas;

    public Camera mainMenuCamera;
    public Camera dialogueCamera;
    public Camera drinkCamera;

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
        dialogueManager.LoadDialogueValues();
        dialogueManager.ChangeState(true);
        ShowDialogueView();
    }

    public void ReturnToMainMenu()
    {
        dialogueManager.ChangeState(false);
        //TODO: deactivate drink manager

        mainMenuCamera.enabled = true;
        dialogueCamera.enabled = false;
        drinkCamera.enabled = false;

        menuCanvas.enable();
        dialogueCanvas.disable();
        drinkCanvas.disable();

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    public void ShowMenuView()
    {
        mainMenuCamera.enabled = true;
        dialogueCamera.enabled = false;
        drinkCamera.enabled = false;

        menuCanvas.enable();
        dialogueCanvas.disable();
        drinkCanvas.disable();
    }

    public void ShowDialogueView()
    {
        dialogueCamera.enabled = true;
        mainMenuCamera.enabled = false;
        drinkCamera.enabled = false;

        dialogueCanvas.enable();
        menuCanvas.disable();
        drinkCanvas.disable();
    }

    public void ShowDrinkView()
    {
        drinkCamera.enabled = true;
        dialogueCamera.enabled = false;
        mainMenuCamera.enabled = false;

        dialogueCanvas.disable();
        menuCanvas.disable();
        drinkCanvas.enable();
    }

    public void SwitchDialogueToDrink()
    {
        //TODO: activate drink manager
        dialogueManager.ChangeState(false);
        ShowDrinkView();
    }
    public void SwitchDrinkToDialogue()
    {
        dialogueManager.ChangeState(true);
        //TODO: deactivate drink manager
        ShowDialogueView();
    }
}
