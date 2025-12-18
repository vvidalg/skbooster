using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayBoy()
    {
        PlayerPrefs.SetString("SelectedPlayer", "Boy");
        SceneManager.LoadScene("World");
    }

    public void PlayGirl()
    {
        PlayerPrefs.SetString("SelectedPlayer", "Girl");
        SceneManager.LoadScene("World");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
