[System.Serializable]
public class Condition
{
    public string name;         // Stat name
    // Only one it's used per condition
    public float min;           // Min stat value to be valid
    public float max;           // Max stat value to be valid

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
