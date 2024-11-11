using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameOver = false;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private Light spotLight;
    [SerializeField] private GameObject playerCar;

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
    }

    void Start()
    {
        // Estado inicial
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(false);
        if (spotLight != null)
            spotLight.enabled = false;
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(true);
        isGameOver = false;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        if (spotLight != null)
            spotLight.enabled = true;
    }

    public void RestartGame()
    {
        Debug.Log("RestartGame iniciado no GameManager");
        
        // Limpa obstáculos primeiro
        ClearObstacles();
        
        // Reseta UI
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(true);
        
        if (spotLight != null)
            spotLight.enabled = false;
        
        // Reseta estado do jogo
        isGameOver = false;
        Time.timeScale = 1f;
        
        // Reseta pontuação
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore();

        // Reseta posição do carro
        if (playerCar != null)
        {
            playerCar.transform.position = new Vector3(0, 0, -8);
            playerCar.transform.rotation = Quaternion.identity;
            
            var rb = playerCar.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
            }
            
            var playerController = playerCar.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ResetPlayer();
            }
        }
    }

    private void ClearObstacles()
    {
        Debug.Log("Iniciando limpeza de obstáculos");
        
        int obstaclesCleared = 0;
        int numbersCleared = 0;
        int wrongAnswersCleared = 0;

        // Encontra e destrói todos os obstáculos
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            DestroyImmediate(obstacle);
            obstaclesCleared++;
        }

        GameObject[] numbers = GameObject.FindGameObjectsWithTag("Numero");
        foreach (GameObject number in numbers)
        {
            DestroyImmediate(number);
            numbersCleared++;
        }

        GameObject[] wrongAnswers = GameObject.FindGameObjectsWithTag("WrongAnswer");
        foreach (GameObject wrong in wrongAnswers)
        {
            DestroyImmediate(wrong);
            wrongAnswersCleared++;
        }

        // Procura por paredes também
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            DestroyImmediate(wall);
        }

        Debug.Log($"Obstáculos removidos: {obstaclesCleared}");
        Debug.Log($"Números removidos: {numbersCleared}");
        Debug.Log($"Respostas erradas removidas: {wrongAnswersCleared}");
    }

    public void ReturnToMenu()
    {
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(false);
        if (spotLight != null)
            spotLight.enabled = false;
        
        isGameOver = false;
        Time.timeScale = 1f;
        
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetScore();
    }
}
