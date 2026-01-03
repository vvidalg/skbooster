using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject EndGamePanel;
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(mainMenuButton.gameObject);
    }

    private void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {    
            EndGamePanel.SetActive(false);
            return;
        }
        else
        {
            EndGamePanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {Debug.Log("[EndGameMAnager] update detecta key.return");
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        ResetGameData();
        Debug.Log("INTENTO DE CARGA DE ESCENA");
        SceneManager.LoadScene("MainMenu");
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