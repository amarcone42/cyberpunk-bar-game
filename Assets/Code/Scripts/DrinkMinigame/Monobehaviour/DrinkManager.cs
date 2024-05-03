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
    private int ingredientDose;
    private float resultAlcohol;
    private bool resultRequirements;

    

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
        if(checkRequirements() == true)
        {
            Debug.Log("checkRequirements è true");
            if(checkConditions() == true)
            {
                gameManager.SwitchDrinkToDialogue(order.GetDay(), order.GetBest());
                Debug.Log("checkConditions è true");
            }
            else
            {
                gameManager.SwitchDrinkToDialogue(order.GetDay(), order.GetGood());
            }
        }
        else
        {
            Debug.Log("checkRequirements è false");
            gameManager.SwitchDrinkToDialogue(order.GetDay(), order.GetFailure());
        }
    }

    private bool checkRequirements()
    {
        resultRequirements = false;

        foreach (Requirement r in order.GetRequirements())
        {
            if(r.category == "alcohol")
            {
                resultRequirements = checkRequirementAlcohol(r);
            }
            else if(r.category == "ingredient")
            {
                resultRequirements = checkRequirementIngredients(r);
            }
        }

        return resultRequirements;
    }

    private bool checkRequirementAlcohol(Requirement r)
    {
        resultAlcohol = drink.GetResult().GetStats().GetAlcohol_level();

        if(resultAlcohol >= r.alcoholMin && resultAlcohol <= r.alcoholMax)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool checkRequirementIngredients(Requirement r)
    {
        ingredientDose = 0;

        foreach(Ingredient i in drink.GetDrinkIngredients())
        {
            if(i.GetName().Equals(r.name))
            {
                ingredientDose++;
            }
        }

        if(ingredientDose == r.dose)
        {
            return true;
        }else
        {
            return false;
        }
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
