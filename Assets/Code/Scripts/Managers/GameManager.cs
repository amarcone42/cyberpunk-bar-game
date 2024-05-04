using Unity.VisualScripting;
using UnityEngine;

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

    public AudioSourceLoop bgm;

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
        DeactivateMenuCamera();
        DeactivateDrinkCamera();
        bgm.StopMusic();
    }

    public void ReturnToMainMenu()
    {
        dialogueManager.ChangeState(false);
        drinkManager.ChangeState(false);

        ActivateMenuCamera();
        DeactivateDialogueCamera();
        DeactivateDrinkCamera();
    }

    public void SwitchDialogueToDrink(Order order)
    {
        drinkManager.ChangeState(true);
        dialogueManager.ChangeState(false);
        ActivateDrinkCamera();
        DeactivateDialogueCamera();
        drinkManager.SetOrder(order);
    }
    public void SwitchDrinkToDialogue(int day, int part)
    {
        dialogueManager.ChangeState(true);
        drinkManager.ChangeState(false);
        ActivateDialogueCamera();
        DeactivateDrinkCamera();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    public void ActivateMenuCamera()
    {
        mainMenuCamera.enabled = true;
        menuCanvas.enable();

        bgm.PlayMusic();
        mainMenuCamera.AddComponent<AudioListener>();
    }
    public void DeactivateMenuCamera()
    {
        mainMenuCamera.enabled = false;
        menuCanvas.disable();

        bgm.StopMusic();
        Destroy(mainMenuCamera.GetComponent<AudioListener>());
    }

    public void ActivateDialogueCamera()
    {
        dialogueCamera.enabled = true;
        dialogueCanvas.enable();

        dialogueCamera.AddComponent<AudioListener>();
    }
    public void DeactivateDialogueCamera()
    {
        dialogueCamera.enabled = false;
        dialogueCanvas.disable();

        Destroy(dialogueCamera.GetComponent<AudioListener>());
    }

    public void ActivateDrinkCamera()
    {
        drinkCamera.enabled = true;
        drinkCanvas.enable();

        drinkCamera.AddComponent<AudioListener>();
    }
    public void DeactivateDrinkCamera()
    {
        drinkCamera.enabled = false;
        drinkCanvas.disable();

        Destroy(drinkCamera.GetComponent<AudioListener>());
    }

}
