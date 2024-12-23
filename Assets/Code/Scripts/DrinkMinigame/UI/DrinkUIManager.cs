using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrinkUIManager : MonoBehaviour
{
    public GameObject infoContainer;
    public TMP_Text infoText;

    public GameObject infoCustomer;
    public TMP_Text infoCustomerText;
    public GameObject customerRequestContainer;
    public TMP_Text customerRequestText;

    // Start is called before the first frame update
    void Start()
    {
        //infoText = infoContainer.transform.Find("InfoText").gameObject.GetComponent<TMP_Text>();
        //infoText = GameObject.Find("InfoText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableInfo(string text)
    {
        infoText.text = text;
        infoContainer.SetActive(true);
    }

    public void DisableInfo()
    {
        infoContainer.SetActive(false);
    }

    public void ShowCustomerInfo(string customer, string request)
    {
        infoCustomerText.text = customer;
        infoCustomer.SetActive(true);
        customerRequestText.text = request;
        customerRequestContainer.SetActive(true);


    }
}
