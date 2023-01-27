using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public string MainMenu;

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
        gameOverMenu.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.AddCoins(CurrentSceneManager.instance.coinsPickedInThisSceneCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        gameOverMenu.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
}
