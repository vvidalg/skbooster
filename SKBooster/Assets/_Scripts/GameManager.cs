using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Progress")]
    [SerializeField] private int currentXP = 0;
    [SerializeField] private bool hasLevelKey = false;
    [SerializeField] private int currentLevel = 0;

    
    public int CurrentXP => currentXP;
    public bool HasLevelKey => hasLevelKey;
    public int CurrentLevel => currentLevel;

    public static event Action<int> OnXPChanged;
    public static event Action<int> OnLevelChanged;
    public static event Action<bool> OnKeyyChanged;

    private void Awake()
    {
        /*if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
            Debug.Log("[GameManager] Creado y persistente");
        }
        else
        {
            Debug.Log("[GameManager] Duplicado detectado, destruyendo este objeto");
            Destroy(gameObject);
        }*/
        LoadData();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerPosX"))
            return;

        Vector3 savedPosition = new Vector3(
            PlayerPrefs.GetFloat("PlayerPosX"),
            PlayerPrefs.GetFloat("PlayerPosY"),
            PlayerPrefs.GetFloat("PlayerPosZ")
        );

        transform.position = savedPosition;
    }
    
    public void SaveData()
    {
        PlayerPrefs.SetInt("CurrentXP", currentXP);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("HasLevelKey", hasLevelKey ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("[GameManager] Datos guardados en PlayerPrefs");
    }
    public void LoadData()
    {
        currentXP = PlayerPrefs.GetInt("CurrentXP", 0);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        hasLevelKey = PlayerPrefs.GetInt("HasLevelKey", 0) == 1;
        OnXPChanged?.Invoke(currentXP);
        OnLevelChanged?.Invoke(currentLevel);
        OnKeyyChanged?.Invoke(hasLevelKey);
        Debug.Log("[GameManager] Datos cargados desde PlayerPrefs: ");
    }

    private void updateData()
    {
        currentXP = PlayerPrefs.GetInt("CurrentXP", 0);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        hasLevelKey = PlayerPrefs.GetInt("HasLevelKey", 0) == 1;
            
        OnXPChanged?.Invoke(currentXP);
        OnLevelChanged?.Invoke(currentLevel);
        OnKeyyChanged?.Invoke(hasLevelKey);

        Debug.Log("[GameManager] Datos cargados desde PlayerPrefs");
    }

    public void AddAssertiveXP()
    {
        currentXP += 250;
        OnXPChanged?.Invoke(currentXP);
        LevelUp();
        SaveData();
    }

    public void GrantLevelKey()
    {
        hasLevelKey = true;
        OnKeyyChanged?.Invoke(hasLevelKey);
        LevelUp();
        SaveData();
    }

    void LevelUp()
    {
        if  (currentXP >= (750 * (currentLevel + 1)))
        {
            if (hasLevelKey)
            {
                currentLevel++;
                OnLevelChanged?.Invoke(currentLevel);
                hasLevelKey = false;
                PlayerPrefs.SetInt("HasLevelKey", 0);
                PlayerPrefs.Save();
                OnKeyyChanged?.Invoke(hasLevelKey);
            }


        }
    }

}
