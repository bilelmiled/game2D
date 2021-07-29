using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameoverUI;
    public static GameOverManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }

    public void OnPlayerDeath ()
    {
        gameoverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.Instance.remove(CurrentSceneManager.Instance.CoinPickedUpInThisScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.Instance.respawn();
        gameoverUI.SetActive(false);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
