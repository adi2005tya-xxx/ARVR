
using UnityEngine;
using TMPro;

public class InfoPanelController : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public void ShowInfo(string title, string description)
    {
        panel.SetActive(true);
        titleText.text = title;
        descriptionText.text = description;
    }

    public void HideInfo()
    {
        panel.SetActive(false);
    }
}
