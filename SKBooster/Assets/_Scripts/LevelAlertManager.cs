using System.Collections;
using UnityEngine;

public class LevelAlertManager : MonoBehaviour
{
    [SerializeField] private GameObject levelAlertPanel;
    [SerializeField] private float alertDuration = 1f;
    
    private Coroutine alertCoroutine;
    private void OnEnable()
    {
        GameManager.OnLevelChanged += HandleLevelChanged;
    }

    private void OnDisable()
    {
        GameManager.OnLevelChanged -= HandleLevelChanged;
    }
    private void HandleLevelChanged(int newlevel)
    {
        if (levelAlertPanel == null||newlevel==0)
        {
            return;
        }
        if (alertCoroutine != null)
            StopCoroutine(alertCoroutine);

        alertCoroutine = StartCoroutine(ShowAlert());
    }
    

    private IEnumerator ShowAlert()
    {
        levelAlertPanel.SetActive(true);
        yield return new WaitForSeconds(alertDuration);
        levelAlertPanel.SetActive(false);
        alertCoroutine = null;
    }
}
