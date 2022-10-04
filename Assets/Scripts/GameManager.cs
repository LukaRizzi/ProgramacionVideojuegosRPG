using RPGUNDAV.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 newPos;

    public bool loadSaveSpot = false;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (PlayerPrefs.HasKey("saveSpotScene") && loadSaveSpot)
        {
            newPos = new Vector2(PlayerPrefs.GetFloat("saveSpotX"), PlayerPrefs.GetFloat("saveSpotY"));

            SceneManager.LoadScene(PlayerPrefs.GetString("saveSpotScene"));
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        if (newPos != null)
            player.transform.position = newPos;

        if (loadSaveSpot)
        {
            loadSaveSpot = false;
            player.GetComponentInChildren<Animator>().Play("PlayerRest");
        }
    }
}