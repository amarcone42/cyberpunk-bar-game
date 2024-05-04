using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientData : MonoBehaviour
{
    private DrinkManager drinkScript;
    private Client client;

    public string clientName;
    public Stats stats;
    public float alcohol_level;
    public float happiness;
    public float anger;
    public float anxiety;
    public float fear;
    public float confident;
    public float tenderness;
    public float energy;

    // Start is called before the first frame update
    void Start()
    {
        drinkScript = GameObject.Find("Controller").GetComponent<DrinkManager>();
        client = new Client(clientName, new Stats(alcohol_level, happiness, anger, anxiety, fear, confident, tenderness, energy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
