using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeButtonText : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        TextMeshProUGUI buttonText = startButton.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = "Iniciar Corrida";
        }
    }   
}
