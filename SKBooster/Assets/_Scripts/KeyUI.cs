using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private GameObject silverKey;
    [SerializeField] private GameObject GoldenKey;
    private bool hasLevelKey;
    
    private void OnEnable()
    {
        GameManager.OnKeyyChanged += UpdateKey;
    }

    private void OnDisable()
    {
        GameManager.OnKeyyChanged -= UpdateKey;
    }
    private void Start()
    {
  
        hasLevelKey = PlayerPrefs.GetInt("HasLevelKey", 0) == 1;
        setCorrectPanel();
    }

    private void setCorrectPanel()
    {
        silverKey.SetActive(!hasLevelKey);
        GoldenKey.SetActive(hasLevelKey);
    }

    private void UpdateKey(bool Key)
    {
        hasLevelKey = Key;
        setCorrectPanel();
    }


}
