using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkIngredient : MonoBehaviour
{
    private DrinkManager drinkScript;
    private Ingredient ingredient;
    public string ingredientName;

    public Stats stats;

    public float alcohol_level;
    public float happiness;
    public float anger;
    public float anxiety;
    public float fear;
    public float confident;
    public float tenderness;
    public float energy;

    // Start is called before the first frame update
    void Start()
    {
        drinkScript = GameObject.Find("Controller").GetComponent<DrinkManager>();
        ingredient = new Ingredient(ingredientName, new Stats(alcohol_level, happiness, anger, anxiety, fear, confident, tenderness, energy));
    }

    void OnMouseDown()
    {
        drinkScript.Add(ingredient);
    }

    void OnMouseEnter()
    {
        drinkScript.showIngredient(ingredient.ToString());
    }

    void OnMouseExit()
    {
        drinkScript.hideIngredient();
    }
}
