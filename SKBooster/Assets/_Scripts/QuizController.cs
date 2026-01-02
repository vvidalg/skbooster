using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    [Header("Título")]
    public TMP_Text titleText;

    [Header("MainMenu")]
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject mainMenuPanel;
    
    [Header("Contenidos")]
    public GameObject contentPanel;
    public TMP_Text contentTitleText;
    public TMP_Text contentBodyText;
    public GameObject leftButton;
    public GameObject rightButton;

    [Header("Quiz")]
    public GameObject quizPanel;
    public TMP_Text scoreText;
    public TMP_Text questionText;
    public TMP_Text buttonAText;
    public TMP_Text buttonBText;
    public TMP_Text buttonCText;

    [Header("Final")]
    public GameObject endPanel;
    public GameObject congratulationsPanel;
    public GameObject tryAgainPanel;

    private QuizJsonData quizData;
    private int contentIndex;
    private int questionIndex;
    private int score;

private void Start()
{
    //quizData = QuizLoader.Load(QuizSessionManager.Instance.CurrentQuizId);
    quizData = QuizLoader.Load(PlayerPrefs.GetString("CurrentQuizId"));
    if (quizData == null)
    {
        Debug.LogError("QuizData no cargado");
        return;
    }

    titleText.text = quizData.title;
    ShowMainMenu();
}

    void ShowContent()
    {
        contentPanel.SetActive(true);
        quizPanel.SetActive(false);
        endPanel.SetActive(false);

        var screen = quizData.contents[contentIndex];
        contentTitleText.text = screen.title;
        contentBodyText.text = screen.text;

        leftButton.SetActive(contentIndex > 0);
        rightButton.SetActive(contentIndex < quizData.contents.Count);

    }

    public void NextContent()
    {
        contentIndex++;
        if (contentIndex >= quizData.contents.Count)
            StartQuiz();
        else
            ShowContent();
    }

    public void PreviousContent()
    {
        contentIndex--;
        ShowContent();
    }

    void StartQuiz()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        mainMenuPanel.SetActive(false);
        contentPanel.SetActive(false);
        quizPanel.SetActive(true);
        score = 0;
        questionIndex = 0;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        var q = quizData.questions[questionIndex];
        questionText.text = q.question;
        buttonAText.text = q.answers[0];
        buttonBText.text = q.answers[1];
        buttonCText.text = q.answers[2];
        scoreText.text = score + "/" + quizData.questions.Count;
    }

    public void Answer(int index)
    {
        if (quizData.questions[questionIndex].correctAnswer == index)
            score++;

        questionIndex++;

        if (questionIndex >= quizData.questions.Count)
            EndQuiz();
        else
            ShowQuestion();
    }

    void EndQuiz()
    {
        quizPanel.SetActive(false);
        endPanel.SetActive(true);

        congratulationsPanel.SetActive(false);
        tryAgainPanel.SetActive(false);
        
        bool passed = score >= quizData.questions.Count / 2;

        congratulationsPanel.SetActive(passed);
        tryAgainPanel.SetActive(!passed);
        PlayerPrefs.SetInt("HasLevelKey", passed ? 1 : 0);
        Debug.Log("[QuizController] EndQuiz" + PlayerPrefs.GetInt("HasLevelKey"));
        //QuizResultManager.Instance.SetResult(quizData.quizId, passed);
        Debug.Log("[QuizController] EndQuiz" + quizData.quizId+" y " + passed);
        
    }

    public void RestartQuiz()
    {
        mainMenuPanel.SetActive(false);
        contentIndex = 0;
        questionIndex = 0;
        score = 0;
        ShowContent();
    }

    public void ExitToWorld()
    {
       SceneManager.LoadScene("World");
    }
    void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        contentPanel.SetActive(false);
        quizPanel.SetActive(false);
        endPanel.SetActive(false);
    }
}
