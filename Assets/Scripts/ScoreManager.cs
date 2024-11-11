using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    private int currentScore = 0;
    private int highScore = 0;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // Carrega o high score salvo
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }
    
    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreText();
        
        // Atualiza o high score se necessário
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }
    
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Pontos: {currentScore}";
        }
    }
    
    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = $"Recorde: {highScore}";
        }
    }
    
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreText();
    }
}