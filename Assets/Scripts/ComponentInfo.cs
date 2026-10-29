
using UnityEngine;

public class ComponentInfo : MonoBehaviour
{
    public string componentName = "Oxygen Bomb";

    [TextArea(3, 8)]
    public string explanation =
        "A sealed vessel used in a bomb calorimeter to hold the sample and oxygen during measurement.";

    private InfoPanelController panelController;

    private void Start()
    {
        panelController = FindFirstObjectByType<InfoPanelController>();
    }

    private void OnMouseDown()
    {
        if (panelController != null)
        {
            panelController.ShowInfo(componentName, explanation);
        }
    }
}
