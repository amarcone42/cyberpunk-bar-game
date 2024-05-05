using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
    public GameObject player;
    public GameObject[] customers;

    public GameObject creditsScreen;

    void Start()
    {
        HideCredits();

        dialogueManager = GetComponent<DialogueSystem>();
        drinkManager = GetComponent<DrinkManager>();
        mainMenuCamera.enabled = true;
        dialogueCamera.enabled = false;
        drinkCamera.enabled = false;
        
        // Characters visibility
        int n = 0;  // Number of customers
        foreach (GameObject character in GameObject.FindGameObjectsWithTag("Character"))
        {
            if (character.name != player.name)
            {
                n++;
            }
        }
        customers = new GameObject[n];
        int i = 0;
        foreach (GameObject character in GameObject.FindGameObjectsWithTag("Character"))
        {
            if (character.name != player.name)
            {
                customers[i] = character;
                i++;
                character.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewGame()
    {
        EnableDialogueScene();
        DisableMenuScene();
        DisableDrinkScene();
        bgm.StopMusic();
        dialogueManager.LoadDialogueValues();
    }

    public void ReturnToMainMenu()
    {
        EnableMenuScene();
        DisableDialogueScene();
        DisableDrinkScene();

        foreach (GameObject customer in customers)
        {
            customer.SetActive(false);
        }
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




    public void EnableMenuScene()
    {
        mainMenuCamera.enabled = true;
        menuCanvas.enable();

        bgm.PlayMusic();
        mainMenuCamera.AddComponent<AudioListener>();
    }
    public void DisableMenuScene()
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



    public void ShowSingleCustomer(string name)
    {
        Debug.Log("Show single character");
        foreach (GameObject customer in customers)
        {
            Debug.Log(customer.name);
            if (customer.name == name)
            {
                Debug.Log("Yes");
                customer.SetActive(true);  // Shows the selected character
            } else {

                Debug.Log("No");
                customer.SetActive(false);
            }
        }
        Debug.Log("End function");
    }

    public void ShowMainCharacter()
    {
        player.SetActive(true);
    }
    public void HideMainCharacter()
    {
        player.SetActive(false);
    }


    public void ShowCredits()
    {
        creditsScreen.SetActive(true);
    }
    public void HideCredits()
    {
        creditsScreen.SetActive(false);
    }
}
