using UnityEngine;

public class PlayerPositionLoader : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.HasKey("HasSavedPlayerPosition"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX", transform.position.x);
            float y = PlayerPrefs.GetFloat("PlayerPosY", transform.position.y);
            float z = PlayerPrefs.GetFloat("PlayerPosZ", transform.position.z);

            transform.position = new Vector3(x, y, z);
            Debug.Log("[PlayerPositionLoader] Posición restaurada: " + transform.position);
        }
        else
        {
            Debug.Log("[PlayerPositionLoader] No hay posición guardada, usando posición por defecto.");
        }
    }
}