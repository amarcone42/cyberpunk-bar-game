using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Add(Stats stats)
    {
        drink.AddComponent(stats);
    }
}
