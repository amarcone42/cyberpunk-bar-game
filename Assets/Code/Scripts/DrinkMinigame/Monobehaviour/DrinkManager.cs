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

    

    public AudioSourceLoop bgm;

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

    public Drink GetDrink()
    {
        return drink;
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
                Debug.Log("checkConditions è false");
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
        resultRequirements = true;

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

            if(resultRequirements == false)
            {
                return resultRequirements;
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
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetAlcohol_level());
                break;

                case "happiness":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetHappiness());
                break;

                case "anger":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetAnger());
                break;

                case "anxiety":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetAnxiety());
                break;

                case "fear":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetFear());
                break;

                case "confident":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetConfident());
                break;

                case "tenderness":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetTenderness());
                break;

                case "energy":
                    resultCheckConditions = checkConditionMinMax(c, drinkStats.GetEnergy());
                break;
            }

            if(resultCheckConditions == false)
            {
                return resultCheckConditions;
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

    public void RemoveAll()
    {
        drink.RemoveComponents();
    }


    public void showIngredient(string ingredientString)
    {
        uiScript.EnableInfo(ingredientString);
    }

    public void hideIngredient()
    {
        uiScript.DisableInfo();
    }

    public void ShowCustomer(string customer, string description)
    {
        uiScript.ShowCustomerInfo(customer, description);
    }
}
