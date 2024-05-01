using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

[System.Serializable]
public class Drink
{
    private const int MaxComponents = 4;
    private List<Stats> drinkComponents;
    private Stats result;

    public Drink()
    {
        drinkComponents = new List<Stats>();
        result = new Stats(0f, 0f);
    }

    public void AddComponent(Stats component)
    {
        if(drinkComponents.Count == MaxComponents)
        {
            throw new DrinkIsFullException(); 
        }else
        {
            drinkComponents.Add(component);
            result = Stats.Stats_Sum(result, component);
        }
        //Debug.Log(drinkComponents.Count);
    }
}
