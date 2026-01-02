/*using UnityEngine;

public class MiniGameEntryController : MonoBehaviour
{
    private string quizId;

    public void Setup(string id)
    {
        quizId = id;
    }

    public void Play()
    {
        QuizSessionManager.Instance.StartQuiz(quizId);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
*/

using UnityEngine;

public class MiniGameEntryController : MonoBehaviour
{
    [SerializeField] private QuizSessionManager quizSessionManager;
    private string quizId;

    public void Setup(string id)
    {
        quizId = id;
    }

    public void Play()
    {
        quizSessionManager.StartQuiz(quizId);
    }

}
