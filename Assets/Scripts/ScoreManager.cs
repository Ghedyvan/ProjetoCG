using UnityEngine;
using UnityEngine.UI;
using TMPro; // Se estiver usando TextMeshPro (recomendado)

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton para acesso fácil
    public TextMeshProUGUI scoreText; // Referência ao texto na UI
    public TextMeshProUGUI highScoreText; // Referência ao texto na UI
    private int currentScore = 0;

    private int highScore;

    [Header("UI Elements")]
    public GameObject scoreCanvas; // Referência para o objeto pai que contém os textos de pontuação

    void Awake()
    {
        // Garante que só existe uma instância
        if (instance == null)
        {
            instance = this;
        }

        highScore = PlayerPrefs.GetInt("Recorde", 0);
        UpdateUI();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;

        if(currentScore > highScore)
        {
            SaveHighScore();
        }

        UpdateUI();
    }

    public void RemoveScore(int score)
    {
        currentScore -= score;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Pontos: " + currentScore.ToString();
        highScoreText.text = "Recorde: " + highScore.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Recorde");
        PlayerPrefs.Save();
        UpdateUI();
    }

    // Opcional: Salvar pontuação máxima
    public void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("Recorde", currentScore - 100);
            PlayerPrefs.Save();
        }
    }

    public void ShowScoreUI(bool show)
    {
        if (scoreCanvas != null)
        {
            scoreCanvas.SetActive(show);
        }
    }
}