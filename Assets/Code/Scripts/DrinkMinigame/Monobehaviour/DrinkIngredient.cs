using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkIngredient : MonoBehaviour
{
    public DrinkManager drinkScript;
    private UIManager uiScript;

    private Ingredient ingredient;
    public string ingredientName;
    public float stat1;
    public float stat2;

    // Start is called before the first frame update
    void Start()
    {
        uiScript = GameObject.Find("Camera Drink").GetComponent<UIManager>();

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
