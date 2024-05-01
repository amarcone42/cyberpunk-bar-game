using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Drink
{
    private const int MaxComponents = 4;
    private Stats[] drinkComponents;
    private Stats result;

    public Drink()
    {
        drinkComponents = new Stats[MaxComponents];
        result = new Stats(0f, 0f);
    }

    public void AddComponent(Stats component)
    {
        if(drinkComponents.Length == MaxComponents)
        {
            throw new DrinkIsFullException(); 
        }else
        {
            drinkComponents[drinkComponents.Length] = component;
            result = Stats.Stats_Sum(result, drinkComponents[drinkComponents.Length-1]);
        }
    }
}
