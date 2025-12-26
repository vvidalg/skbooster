using System.Collections;
using UnityEngine;
using TMPro;

public class XPUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xpText;
    

    private void OnEnable()
    {
        GameManager.OnXPChanged += UpdateXP;
    }

    private void OnDisable()
    {
        GameManager.OnXPChanged -= UpdateXP;
    }

    private void Start()
    {
  
        UpdateXP(0);
    }

    private void UpdateXP(int newXP)
    {
        xpText.text = $"XP: {newXP}";

    }



}