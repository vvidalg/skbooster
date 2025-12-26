using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject xpAlertPanel;
    [SerializeField] private float alertDuration = 1f;

    private Coroutine alertCoroutine;

    private void OnEnable()
    {
        GameManager.OnXPChanged += HandleXPChanged;
    }

    private void OnDisable()
    {
        GameManager.OnXPChanged -= HandleXPChanged;
    }

    private void HandleXPChanged(int newXP)
    {
        if (xpAlertPanel == null)
        {
            Debug.LogError("XPAlertPanel no asignado en XPAlertListener");
            return;
        }

        if (alertCoroutine != null)
            StopCoroutine(alertCoroutine);

        alertCoroutine = StartCoroutine(ShowAlert());
    }

    private IEnumerator ShowAlert()
    {
        xpAlertPanel.SetActive(true);
        yield return new WaitForSeconds(alertDuration);
        xpAlertPanel.SetActive(false);
        alertCoroutine = null;
    }
}
