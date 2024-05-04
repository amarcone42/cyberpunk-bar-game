
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChapterScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chaptername;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Show(int number)
    {
        gameObject.SetActive(true);
        chaptername.text = "Chapter " + number;
    }
}
