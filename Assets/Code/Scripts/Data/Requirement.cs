[System.Serializable]
public class Requirement
{
    public string category;     // Requirement category can be ingredient or alcohol
    // Patameters for ingredient
    public string name;             // Ingredient name
    public int dose;                // Min dose of the ingredient
    // Parameters for alcohol
    public float alcoholMin;        // Min alcohol required
    public float alcoholMax;        // Max alcohol required

    public override string ToString()
    {
        return "category: " + category +
        "\n" + "name: " + name + 
        "\n" + "dose: " + dose +
        "\n" + "alcoholMin: " + alcoholMin +
        "\n" + "alcoholMax: " + alcoholMax + " ";
    }
}