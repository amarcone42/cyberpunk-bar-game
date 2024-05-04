[System.Serializable]
public class Condition
{
    public string name;         // Stat name
    // Only one it's used per condition
    public string bound;          //can be "min" or "max", determines the meaning of value
    public float value;           // Min or Max stat value to be valid

    public override string ToString()
    {
        return "name: " + name +
        "\n" + "bound: " + bound +
        "\n" + "value: " + value + " ";
    }

    /*
     * Name values:
     * alcohol_level
     * happiness
     * anger
     * anxiety
     * fear
     * confident
     * tenderness
     * energy
     */
}   
