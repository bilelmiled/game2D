using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string leveltoload;
    public GameObject SettingsPannel;


    public void StartGame()
    {
        SceneManager.LoadScene(leveltoload);
    }

    public void SettingsGame()
    {
        SettingsPannel.SetActive(true);
    }

    public void CloseSettingsGame()
    {
        SettingsPannel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
