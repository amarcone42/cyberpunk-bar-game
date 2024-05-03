using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeDrink : MonoBehaviour
{
    private DrinkManager drinkScript;

    // Start is called before the first frame update
    void Start()
    {
        drinkScript = GameObject.Find("Controller").GetComponent<DrinkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        drinkScript.checkDrink();
    }
}
