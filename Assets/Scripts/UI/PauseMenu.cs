using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public void OpenPauseMenu(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if(isPaused) 
        {
            gameObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            gameObject.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }

    public void ResumeButtonClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
        isPaused = false;
    }

    public void RestartButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPaused = false;
    }

    public void MainMenuButtonClick(string scene)
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
        Cursor.visible = true;
    }

    public void ExitGameButtonClick()
    {
        Application.Quit();
    }
}
