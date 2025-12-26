using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Player Progress")]
    [SerializeField] private int currentXP = 0;
    [SerializeField] private bool hasLevelKey = false;

    public int CurrentXP => currentXP;
    public bool HasLevelKey => hasLevelKey;

    // Evento para la UI
    public static event Action<int> OnXPChanged;

    // =========================
    // XP MANAGEMENT
    // =========================

    public void AddAssertiveXP()
    {
        currentXP += 250;
        Debug.Log("[GameManager] +250 XP por respuesta asertiva. XP total: " + currentXP);

        OnXPChanged?.Invoke(currentXP);

    }

    public void ResetXP()
    {
        currentXP = 0;
        OnXPChanged?.Invoke(currentXP);
    }

    public void GrantLevelKey()
    {
        hasLevelKey = true;
        Debug.Log("[GameManager] Llave de nivel obtenida");
    }

    public void UseLevelKey()
    {
        hasLevelKey = false;
    }
}