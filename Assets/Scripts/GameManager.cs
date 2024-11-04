using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;

    void Start()
    {
        Time.timeScale = 0f; // Pausa o jogo
        startMenu.SetActive(true); // Exibe o menu inicial
    }

    public void StartGame()
    {
        Debug.Log("Game started");
        Time.timeScale = 1f; // Retoma o jogo
        startMenu.SetActive(false); // Esconde o menu inicial
    }
}
