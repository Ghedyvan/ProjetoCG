using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameManager gameManager;

    public void OnStartButtonPressed()
    {
        Debug.Log("Start button pressed");
        gameManager.StartGame();
    }
}
