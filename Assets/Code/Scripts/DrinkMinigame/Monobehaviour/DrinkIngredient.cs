using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkIngredient : MonoBehaviour
{
    private DrinkManager drinkScript;
    private DrinkUIManager uiScript;

    private Ingredient ingredient;
    public string ingredientName;
    public float stat1;
    public float stat2;

    // Start is called before the first frame update
    void Start()
    {
        drinkScript = GameObject.Find("Controller").GetComponent<DrinkManager>();
        uiScript = GameObject.Find("Controller").GetComponent<DrinkUIManager>();

        ingredient = new Ingredient(ingredientName, new Stats(stat1, stat2));
    }

    void OnMouseDown()
    {
        Debug.Log(ingredient.getName());
        drinkScript.Add(ingredient);
    }

    void OnMouseEnter()
    {
        uiScript.EnableInfo(ingredient.ToString());
    }

    void OnMouseExit()
    {
        uiScript.DisableInfo();
    }
}
