using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private string ingredientName;
    private Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        ingredientName = "vodka";
        stats = new Stats(0.2f, 0.5f);
    }

    void OnMouseDown()
    {
        Debug.Log(this.ingredientName);
    }

    void OnMouseOver()
    {

    }
}
