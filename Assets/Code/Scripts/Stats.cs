using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Stats
{
    private float parametro1 {get; set;}
    private float parametro2 {get; set;}

    public Stats(float stat1, float stat2)
    {
        this.parametro1 = stat1;
        this.parametro2 = stat2;
    }

    public static Stats Stats_Sum(Stats firstStats, Stats secondStats)
    {
        Stats result = new Stats(0f, 0f);

        result.parametro1 = Parameters_Sum(firstStats.parametro1, secondStats.parametro1);
        result.parametro2 = Parameters_Sum(firstStats.parametro2, secondStats.parametro2);
        
        return result;
    }

    private static float Parameters_Sum(float firstParameter, float secondParameter)
    {
        return firstParameter + secondParameter;
    }
}
