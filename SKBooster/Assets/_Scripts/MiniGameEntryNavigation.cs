using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGameEntryNavigation : MonoBehaviour
{
    [Header("Botones")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        // Selecciona el botón Jugar al abrir el panel
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            EventSystem.current.SetSelectedGameObject(playButton.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            EventSystem.current.SetSelectedGameObject(exitButton.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject,
                new BaseEventData(EventSystem.current),
                ExecuteEvents.submitHandler
            );
        }
    }
}
