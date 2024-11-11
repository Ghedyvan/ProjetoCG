using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Carrega a cena do jogo (MainGame)
        SceneManager.LoadScene("MainGame");
    }

    public void ResetHighScore()
    {
        ScoreManager.instance.ResetHighScore();
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
}