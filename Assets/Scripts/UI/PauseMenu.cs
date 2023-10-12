using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private InputManager playerInputManager;

    private void Awake()
    {
        playerInputManager = playerObject.GetComponent<InputManager>();
    }
    
    public void OpenPauseMenu(InputAction.CallbackContext context)
    {
        if(!playerObject.GetComponent<InputManager>().isPaused)
        {
            gameObject.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            playerInputManager.isPaused = true;
        }
    }

    public void ResumeButtonClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
        playerInputManager.isPaused = false;
    }

    public void RestartButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerInputManager.isPaused = false;
    }

    public void MainMenuButtonClick(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
        Cursor.visible = true;
        playerInputManager.isPaused = false;
    }

    public void NextLevelButtonClick()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
            playerInputManager.isPaused = false;
        }
        else
            SceneManager.LoadScene("MainMenu_01");
    }

    public void ExitGameButtonClick()
    {
        Application.Quit();
    }
}
