using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonText : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        Text buttonText = startButton.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = "Iniciar Jogo";
        }
    }
}
