using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextArchitect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charname;
    [SerializeField] TextMeshProUGUI charwords;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewMessage(Message message)
    {
        charname.text = message.GetSpeaker();
        charwords.text = message.GetText();
    }
}
