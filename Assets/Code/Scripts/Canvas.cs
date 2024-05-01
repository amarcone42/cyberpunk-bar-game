using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    public void disable()
    {
        GetComponent<GraphicRaycaster>().enabled = false;
    }

    public void enable()
    {
        GetComponent<GraphicRaycaster>().enabled = true;
    }
}
