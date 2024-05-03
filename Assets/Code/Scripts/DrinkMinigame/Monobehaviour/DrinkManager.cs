using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkManager : MonoBehaviour
{
    private GameManager gameManager;
    private Boolean managerStatus = false;
    private DrinkUIManager uiScript;
    private Drink drink;
    private Order order;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        uiScript = GameObject.Find("Controller").GetComponent<DrinkUIManager>();
        drink = new Drink();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(Boolean state)
    {
        managerStatus = state;
    }

    public void SetOrder(Order order)
    {
        this.order = order;
    }

    public void checkDrink()
    {
        // Controllo sul risultato del drink
        Debug.Log(order.GetDay());

        // Restituzione parametri del risultato
        gameManager.SwitchDrinkToDialogue(order.GetDay(), order.GetBest());
    }

    private bool checkRequirements()
    {
        return true;
    }

    private bool checkConditions()
    {
        return true;
    }

    //single ingredient operations
    public void Add(Ingredient ingredient)
    {
        try
        {
            drink.AddComponent(ingredient);
        }catch(DrinkIsFullException)
        {
            Debug.Log("Non puoi aggiungere altri ingredienti");
        }
        
    }

    public void showIngredient(string ingredientString)
    {
        uiScript.EnableInfo(ingredientString);
    }

    public void hideIngredient()
    {
        uiScript.DisableInfo();
    }
}
