
using TMPro;
using UnityEngine;

public class TextArchitect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charname;
    [SerializeField] TextMeshProUGUI charwords;

    public void WriteMessage(Message message)
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
        Debug.Log("Posizione testo = x:" + transform.localPosition.x + " y:" + transform.localPosition.y + " z:" + transform.localPosition.z);
        charname.text = message.GetSpeaker();
        charwords.text = message.GetText();
    }
}
