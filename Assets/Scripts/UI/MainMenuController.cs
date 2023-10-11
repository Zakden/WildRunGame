using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
