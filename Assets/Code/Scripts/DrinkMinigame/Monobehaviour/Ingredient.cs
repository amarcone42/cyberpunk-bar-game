using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private string ingredientName;
    private Stats stats;
    public DrinkManager script;

    // Start is called before the first frame update
    void Start()
    {
        ingredientName = "vodka";
        stats = new Stats(0.2f, 0.5f);
    }

    void OnMouseDown()
    {
        script.Add(stats);
        Debug.Log(this.ingredientName);
    }

    void OnMouseOver()
    {

    }
}
