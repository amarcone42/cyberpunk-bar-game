using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Drink
{
    private const int MaxIngredients = 4;
    private List<Ingredient> drinkIngredients;
    private Ingredient result;

    public List<Ingredient> GetDrinkIngredients()
    {
        return drinkIngredients;
    }

    public Ingredient GetResult()
    {
        return result;
    }

    public Drink()
    {
        drinkIngredients = new List<Ingredient>();
        result = new Ingredient("Result", new Stats(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f));
    }

    public void AddComponent(Ingredient ingredient)
    {
        if(drinkIngredients.Count == MaxIngredients)
        {
            throw new DrinkIsFullException(); 
        }else
        {
            drinkIngredients.Add(ingredient);
            result.setStats(Stats.Stats_Sum(result.GetStats(), ingredient.GetStats()));
            Debug.Log(drinkIngredients.Count);
        }
    }
}
