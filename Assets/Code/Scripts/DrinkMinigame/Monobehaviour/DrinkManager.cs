using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkManager : MonoBehaviour
{
    private Drink drink;

    // Start is called before the first frame update
    void Start()
    {
        drink = new Drink();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(Ingredient ingredient)
    {
        try
        {
            drink.AddComponent(ingredient);
        }catch(DrinkIsFullException)
        {
            Debug.Log("Non puoi aggiungere altri ingredienti");
        }
        
    }
}
