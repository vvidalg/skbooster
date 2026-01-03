using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LevelText;
    private void OnEnable()
    {
        GameManager.OnLevelChanged += UpdateLevel;

        if (GameManager.Instance != null)
            UpdateLevel(GameManager.Instance.CurrentLevel);
    }

    private void OnDisable()
    {
        GameManager.OnLevelChanged -= UpdateLevel;
    }

    private void Start()
    {

        LevelText.text = $"Level: {PlayerPrefs.GetInt("CurrentLevel").ToString()}";;
    }

    private void UpdateLevel(int newLevel)
    {
        LevelText.text = $"Level: {newLevel}";

    }

}
