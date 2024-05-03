using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DialogueSystem dialogueManager;
    private DrinkManager drinkManager;
    [SerializeField] CCanvas menuCanvas;
    [SerializeField] CCanvas dialogueCanvas;
    [SerializeField] CCanvas drinkCanvas;

    public Camera mainMenuCamera;
    public Camera dialogueCamera;
    public Camera drinkCamera;

    void Start()
    {
        dialogueManager = GetComponent<DialogueSystem>();
        drinkManager = GetComponent<DrinkManager>();
        mainMenuCamera.enabled = true;
        dialogueCamera.enabled = false;
        drinkCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewGame()
    {
        dialogueManager.LoadDialogueValues();
        dialogueManager.ChangeState(true);
        ActivateDialogueCamera();
    }

    public void ReturnToMainMenu()
    {
        dialogueManager.ChangeState(false);
        //TODO: deactivate drink manager

        ActivateMenuCamera();
    }

    public void SwitchDialogueToDrink(Order order)
    {
        drinkManager.ChangeState(true);
        dialogueManager.ChangeState(false);
        ActivateDrinkCamera();
        drinkManager.SetOrder(order);
    }
    public void SwitchDrinkToDialogue(int day, int part)
    {
        dialogueManager.ChangeState(true);
        drinkManager.ChangeState(false);
        ActivateDialogueCamera();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    public void ActivateMenuCamera()
    {
        mainMenuCamera.enabled = true;
        dialogueCamera.enabled = false;
        drinkCamera.enabled = false;

        menuCanvas.enable();
        dialogueCanvas.disable();
        drinkCanvas.disable();
    }

    public void ActivateDialogueCamera()
    {
        dialogueCamera.enabled = true;
        mainMenuCamera.enabled = false;
        drinkCamera.enabled = false;

        dialogueCanvas.enable();
        menuCanvas.disable();
        drinkCanvas.disable();
    }

    public void ActivateDrinkCamera()
    {
        drinkCamera.enabled = true;
        dialogueCamera.enabled = false;
        mainMenuCamera.enabled = false;

        
        dialogueCanvas.disable();
        menuCanvas.disable();
        drinkCanvas.enable();

    }

    
}
