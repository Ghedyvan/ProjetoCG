using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public Image backgroundImage; // Referência à imagem de fundo

    void Start()
    {
        Time.timeScale = 0f; // Pausa o jogo
        startMenu.SetActive(true); // Exibe o menu inicial
        SetBackgroundTransparency(1f); // Torna o fundo visível
        SetBackgroundFullscreen(); // Ajusta o fundo para fullscreen
    }

    public void StartGame()
    {
        Debug.Log("Game started");
        Time.timeScale = 1f; // Retoma o jogo
        startMenu.SetActive(false); // Esconde o menu inicial
        SetBackgroundTransparency(0f); // Torna o fundo invisível
    }

    private void SetBackgroundTransparency(float alpha)
    {
        Color color = backgroundImage.color;
        color.a = alpha;
        backgroundImage.color = color;
    }

    private void SetBackgroundFullscreen()
    {
        RectTransform rectTransform = backgroundImage.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
