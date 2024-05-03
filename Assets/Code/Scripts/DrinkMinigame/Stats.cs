using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Stats
{
    private float alcohol_level;
    private float happiness;
    private float anger;
    private float anxiety;
    private float fear;
    private float confident;
    private float tenderness;
    private float energy;

    public float GetAlcohol_level()
    {
        return alcohol_level;
    }
    public float GetHappiness()
    {
        return happiness;
    }
    public float GetAnger()
    {
        return anger;
    }
    public float GetAnxiety()
    {
        return anxiety;
    }
    public float GetFear()
    {
        return fear;
    }
    public float GetConfident()
    {
        return confident;
    }
    public float GetTenderness()
    {
        return tenderness;
    }
    public float GetEnergy()
    {
        return energy;
    }

    public Stats( float alcohol_level, float happiness, float anger, float anxiety, float fear, float confident, float tenderness, float energy)
    {
        this.alcohol_level = alcohol_level;
        this.happiness = happiness;
        this.anger = anger;
        this.anxiety = anxiety;
        this.fear = fear;
        this.confident = confident;
        this.tenderness = tenderness;
        this.energy = energy;
    }

    public static Stats Stats_Sum(Stats firstStats, Stats secondStats)
    {
        Stats result = new Stats(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);

        result.alcohol_level = Parameters_Sum(firstStats.alcohol_level, secondStats.alcohol_level);
        result.happiness = Parameters_Sum(firstStats.happiness, secondStats.happiness);
        result.anger = Parameters_Sum(firstStats.anger, secondStats.anger);
        result.anxiety = Parameters_Sum(firstStats.anxiety, secondStats.anxiety);
        result.fear = Parameters_Sum(firstStats.fear, secondStats.fear);
        result.confident = Parameters_Sum(firstStats.confident, secondStats.confident);
        result.tenderness = Parameters_Sum(firstStats.tenderness, secondStats.tenderness);
        result.energy = Parameters_Sum(firstStats.energy, secondStats.energy);
        
        return result;
    }

    private static float Parameters_Sum(float firstParameter, float secondParameter)
    {
        return firstParameter + secondParameter;
    }

    public override string ToString()
    {
        return "alcohol_level: " + GetAlcohol_level() +
        "\n" + "happiness: " + GetHappiness() + 
        "\n" + "anger: " + GetAnger() +
        "\n" + "anxiety: " + GetAnxiety() +
        "\n" + "fear: " + GetFear() +
        "\n" + "confident: " + GetConfident() + 
        "\n" + "tenderness: " + GetTenderness() +
        "\n" + "energy: " + GetEnergy() + " ";
    }
}
