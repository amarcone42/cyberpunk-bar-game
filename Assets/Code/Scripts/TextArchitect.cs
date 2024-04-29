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
        Vector3 characterpos = new Vector3();
        foreach (GameObject character in GameObject.FindGameObjectsWithTag("Character"))
        {
            if(character.name == message.GetSpeaker())
            {
                characterpos = character.transform.position;
                if(character.name != "Barman")
                {
                    characterpos.x *= -1;
                }
            }
        }
        transform.localPosition = new Vector3(characterpos.x, characterpos.y + 120, transform.localPosition.z);
        Debug.Log("hey");
        Debug.Log("Posizione = x:" + transform.localPosition.x + " y:" + transform.localPosition.y + " z:" + transform.localPosition.z);
        charname.text = message.GetSpeaker();
        charwords.text = message.GetText();
    }
}
