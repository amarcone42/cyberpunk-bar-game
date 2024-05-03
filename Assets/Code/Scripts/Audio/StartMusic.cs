using UnityEngine;

public class StartMusic : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSourceLoop>().PlayMusic();
    }
}
