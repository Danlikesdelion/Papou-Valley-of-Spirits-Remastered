using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public string mainMenu;

    public static GameOverManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }
    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.AddCoins(CurrentSceneManager.instance.coinsPickedInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
}
