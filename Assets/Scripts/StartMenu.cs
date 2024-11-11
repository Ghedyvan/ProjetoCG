using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void StartGame()
    {
        if (gameManager != null)
        {
            gameManager.StartGame();
            Debug.Log("Jogo iniciado");
        }
        else
        {
            Debug.LogError("GameManager não encontrado!");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Jogo fechado");
    }
}
