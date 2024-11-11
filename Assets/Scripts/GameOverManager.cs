using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Lighting Settings")]
    public Light directionalLight;
    public float normalIntensity = 1f;
    public float darkIntensity = 0.3f;
    public float darkTransitionDuration = 0.5f;

    [Header("Spotlight Settings")]
    public Light spotLight; // Referência para a luz
    public float maxIntensity = 8f; // Intensidade máxima da luz
    public float fadeInDuration = 0.5f; // Duração do fade da luz
    public Color spotlightColor = Color.yellow; // Cor da luz

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameOverPanel.SetActive(false);
        
        // Inicializa a luz desligada
        if (spotLight != null)
        {
            spotLight.intensity = 0;
            spotLight.color = spotlightColor;
        }

        if (directionalLight != null)
        {
            directionalLight.intensity = normalIntensity;
        }
    }

    public void ShowGameOver()
    {
        float elapsedTime = 0;

        ScoreManager.instance.ShowScoreUI(false);

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            float intensity = Mathf.Lerp(0, maxIntensity, elapsedTime / fadeInDuration);
            float globalLightIntensity = Mathf.Lerp(normalIntensity, darkIntensity, elapsedTime / fadeInDuration);
            
            spotLight.intensity = intensity;
            directionalLight.intensity = globalLightIntensity;
        }

        Time.timeScale = 0f;

        finalScoreText.text = "Pontuação: " + ScoreManager.instance.GetCurrentScore().ToString();
        highScoreText.text = "Recorde: " + PlayerPrefs.GetInt("Recorde", 0).ToString();
        
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Mostra a UI de pontuação novamente antes de reiniciar
        ScoreManager.instance.ShowScoreUI(true);

        if (directionalLight != null)
        {
            directionalLight.intensity = normalIntensity;
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        if (directionalLight != null)
        {
            directionalLight.intensity = normalIntensity;
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        SceneManager.LoadScene("MainMenu");
    }
}