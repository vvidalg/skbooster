using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private string quizId;

    [Header("UI")]
    [SerializeField] private GameObject miniGameEntryPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        MiniGameEntryController controller = miniGameEntryPanel.GetComponent<MiniGameEntryController>();
        controller.Setup(quizId);
        miniGameEntryPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        miniGameEntryPanel.SetActive(false);
    }
}
