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
    private Stats drinkStats;
    private bool resultCheckConditions;

    

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
        Debug.Log("Inizio a stampare i requirements");
        foreach(Requirement r in order.GetRequirements())
        {
            Debug.Log(r.ToString());
        }
        Debug.Log("Fine stampa requirements");

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
                Debug.Log("ingredient category");
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
            Debug.Log("ingredient name: " + i.GetName());
            Debug.Log("requirement name: " + r.name);
            if(i.GetName().Equals(r.name))
            {
                Debug.Log("i nomi sono uguali");
                ingredientDose++;
            }
        }

        Debug.Log("ingredient doses :" + ingredientDose);
        Debug.Log("required doses :" + r.dose);
        if(ingredientDose >= r.dose)
        {
            return true;
        }else
        {
            return false;
        }
    }

    private bool checkConditions()
    {
        resultCheckConditions = true;
        drinkStats = drink.GetResult().GetStats();

        foreach(Condition c in order.GetConditions())
        {
            switch(c.name)
            {
                case "alcohol_level":
                    if(checkConditionMinMax(c, drinkStats.GetAlcohol_level()) == false)
                    {
                        return (resultCheckConditions = false);
                    }
                break;
            }
        }

        return resultCheckConditions;
    }

    private bool checkConditionMinMax(Condition c, float drinkParameter)
    {
        if(c.bound.Equals("min"))
        {
            if(drinkParameter >= c.value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(drinkParameter <= c.value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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
