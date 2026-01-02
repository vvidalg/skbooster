using System.Collections;
using UnityEngine;

public class KeyAlertMAnager : MonoBehaviour
{
    [SerializeField] private GameObject keyAlertPanel;
    [SerializeField] private float alertDuration = 1f;

    private Coroutine alertCoroutine;
    
    private void OnEnable()
    {
        GameManager.OnKeyyChanged += HandleKeyChanged;
    }

    private void OnDisable()
    {
        GameManager.OnKeyyChanged -= HandleKeyChanged;
    }

    private void HandleKeyChanged(bool key)
    {
        if (keyAlertPanel == null || !key)
        {
            return;
        }
        if (alertCoroutine != null)
            StopCoroutine(alertCoroutine);

        alertCoroutine = StartCoroutine(ShowAlert());
    }

    private IEnumerator ShowAlert()
    {
        keyAlertPanel.SetActive(true);
        yield return new WaitForSeconds(alertDuration);
        keyAlertPanel.SetActive(false);
        alertCoroutine = null;
    }
}
