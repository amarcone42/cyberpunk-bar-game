using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Ingredient
{
    private string name;
    private Stats stats;

    public string GetName()
    {
        return name;
    }
    public Stats GetStats() 
    {
        return stats;
    }

    public void setName(string name)
    {
        this.name = name;
    }
    public void setStats(Stats stats) 
    {
        this.stats = stats;
    }

    public Ingredient(string name, Stats stats)
    {
        this.name = name;
        this.stats = stats;
    }

    public override string ToString()
    {
        return "Name: " + GetName() + "\n" + "Stats:\n" + stats.ToString() + " ";
    }
}
