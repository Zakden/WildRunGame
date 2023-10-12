using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnExitFromGameButtonClick()
    {
        Application.Quit();
    }

    public void SelectLevelButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
