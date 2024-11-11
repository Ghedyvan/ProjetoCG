using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Light spotLight;
    [SerializeField] private Transform playerCar;

    public void ShowGameOver()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        if (spotLight != null)
        {
            spotLight.enabled = true;
            spotLight.transform.position = new Vector3(
                playerCar.position.x,
                playerCar.position.y + 10f,
                playerCar.position.z
            );
        }
    }

    public void RestartGame()
    {
        Debug.Log("Botão Restart pressionado");
        
        if (spotLight != null)
        {
            spotLight.enabled = false;
        }
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
            Debug.Log("RestartGame chamado no GameManager");
        }
        else
        {
            Debug.LogError("GameManager não encontrado!");
        }
    }

    public void GoToMainMenu()
    {
        if (spotLight != null)
        {
            spotLight.enabled = false;
        }
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ReturnToMenu();
        }
    }
}