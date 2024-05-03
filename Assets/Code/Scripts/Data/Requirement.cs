[System.Serializable]
public class Requirement
{
    public string category;     // Requirement category can be ingredient or alcohol
    // Patameters for ingredient
    public int name;                // Ingredient name
    public int dose;                // Min dose of the ingredient
    // Parameters for alcohol
    public float alcoholMin;        // Min alcohol required
    public float alcoholMax;        // Max alcohol required
}