using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached",1);
        for (int i = levelReached; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
