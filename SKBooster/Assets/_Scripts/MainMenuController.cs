using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayBoy()
    {
        ResetGameData();
        PlayerPrefs.SetString("SelectedPlayer", "Boy");
        SceneManager.LoadScene("World");
    }

    public void PlayGirl()
    {
        ResetGameData();
        PlayerPrefs.SetString("SelectedPlayer", "Girl");
        SceneManager.LoadScene("World");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void ResetGameData()
    {
 
        PlayerPrefs.DeleteKey("CurrentXP");
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("HasLevelKey");
        PlayerPrefs.DeleteKey("PlayerPosX");
        PlayerPrefs.DeleteKey("PlayerPosY");
        PlayerPrefs.DeleteKey("PlayerPosZ");
        PlayerPrefs.DeleteKey("HasSavedPlayerPosition");

        PlayerPrefs.Save();

        Debug.Log("[MainMenu] PlayerPrefs de partida reiniciados");
    }
}
