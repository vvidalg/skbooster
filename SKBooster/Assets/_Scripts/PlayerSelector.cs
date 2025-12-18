using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject playerBoy;
    public GameObject playerGirl;
    public GameObject camBoy;
    public GameObject camGirl;

    void Start()
   
    {
        string selectedPlayer = PlayerPrefs.GetString("SelectedPlayer", "Boy");

        if (selectedPlayer == "Boy")
        {
            playerBoy.SetActive(true);
            camBoy.SetActive(true);
            playerGirl.SetActive(false);
            camGirl.SetActive(false);
        }
        else
        {
            playerBoy.SetActive(false);
            camBoy.SetActive(false);
            playerGirl.SetActive(true);
            camGirl.SetActive(true);
        }
    }
}
