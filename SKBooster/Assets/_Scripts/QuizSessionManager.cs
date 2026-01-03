using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizSessionManager : MonoBehaviour
{
    public static QuizSessionManager Instance;
    public string CurrentQuizId;
    [SerializeField] private Transform playerBoy;
    [SerializeField] private Transform playerGirl;

    public void StartQuiz(string quizId)
    {
        if (string.IsNullOrEmpty(quizId))
        {
            Debug.LogError("[QuizSessionManager] quizId inválido");
            return;
        }

        PlayerPrefs.SetString("CurrentQuizId", quizId);

        SavePlayerPosition();

        SceneManager.LoadScene("MiniGame");
    }

    private void SavePlayerPosition()
    {
        string selectedPlayer = PlayerPrefs.GetString("SelectedPlayer", "Boy");

        Transform player = selectedPlayer == "Boy" ? playerBoy : playerGirl;

        if (player == null)
        {
            Debug.LogError("[QuizSessionManager] Referencia al jugador no asignada");
            return;
        }

        Vector3 pos = player.position;

        PlayerPrefs.SetFloat("PlayerPosX", pos.x);
        PlayerPrefs.SetFloat("PlayerPosY", pos.y);
        PlayerPrefs.SetFloat("PlayerPosZ", pos.z);
        PlayerPrefs.SetInt("HasSavedPlayerPosition", 1);

        PlayerPrefs.Save();
    }
}

