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
        EnableDialogueScene();
        DisableMenuCamera();
        DisableDrinkScene();
        bgm.StopMusic();
    }

    public void ReturnToMainMenu()
    {
        EnableMenuCamera();
        DisableDialogueScene();
        DisableDrinkScene();
    }

    public void SwitchDialogueToDrink(Order order)
    {
        EnableDrinkScene();
        DisableDialogueScene();
        drinkManager.SetOrder(order);
    }
    public void SwitchDrinkToDialogue(int day, int part)
    {
        EnableDialogueScene();
        DisableDrinkScene();
        dialogueManager.ChangeScene(day, part);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    public void EnableMenuCamera()
    {
        mainMenuCamera.enabled = true;
        menuCanvas.enable();

        bgm.PlayMusic();
        mainMenuCamera.AddComponent<AudioListener>();
    }
    public void DisableMenuCamera()
    {
        mainMenuCamera.enabled = false;
        menuCanvas.disable();

        bgm.StopMusic();
        Destroy(mainMenuCamera.GetComponent<AudioListener>());
    }

    public void EnableDialogueScene()
    {
        dialogueManager.ChangeState(true);

        dialogueCamera.enabled = true;
        dialogueCanvas.enable();

        dialogueCamera.AddComponent<AudioListener>();
    }
    public void DisableDialogueScene()
    {
        dialogueManager.ChangeState(false);

        dialogueCamera.enabled = false;
        dialogueCanvas.disable();

        Destroy(dialogueCamera.GetComponent<AudioListener>());
    }

    public void EnableDrinkScene()
    {
        drinkManager.ChangeState(true);

        drinkCamera.enabled = true;
        drinkCanvas.enable();

        drinkCamera.AddComponent<AudioListener>();
    }
    public void DisableDrinkScene()
    {
        drinkManager.ChangeState(false);

        drinkCamera.enabled = false;
        drinkCanvas.disable();

        Destroy(drinkCamera.GetComponent<AudioListener>());
    }

}
