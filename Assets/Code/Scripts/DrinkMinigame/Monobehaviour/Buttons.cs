using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private DrinkManager drinkScript;

    // Start is called before the first frame update
    void Start()
    {
        drinkScript = GameObject.Find("Controller").GetComponent<DrinkManager>();
        this.GetComponent<Button>().onClick.AddListener(taskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void taskOnClick()
    {
        if(this.name == "Serve")
        {
            drinkScript.checkDrink();
        }

        if(this.name == "Reset")
        {
            drinkScript.RemoveAll();
        }
    }
}
