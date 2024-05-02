using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkIngredient : MonoBehaviour
{
    private Ingredient ingredient;
    public DrinkManager script;

    // Start is called before the first frame update
    void Start()
    {
        ingredient = new Ingredient("vodka", new Stats(0.2f, 0.5f));
    }

    void OnMouseDown()
    {
        Debug.Log(ingredient.getName());
        script.Add(ingredient);
    }

    void OnMouseOver()
    {

    }
}
