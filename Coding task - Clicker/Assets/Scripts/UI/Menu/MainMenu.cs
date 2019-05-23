using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game. Referenced in UI elements.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Exits the game. Referenced in UI elements.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
