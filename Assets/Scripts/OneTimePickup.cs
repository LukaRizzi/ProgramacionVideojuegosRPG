using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneTimePickup : MonoBehaviour
{
    string ID;

    private void Start()
    {
        ID = SceneManager.GetActiveScene().name + "." + (Mathf.Round(transform.position.x * 10)/10).ToString() + "." + (Mathf.Round(transform.position.y * 10) / 10).ToString();
        //Debug.Log(ID);

        if (PlayerPrefs.GetInt(ID, 0) == 1)
            Destroy(this.gameObject);
    }

    public void PickedUp()
    {
        PlayerPrefs.SetInt(ID, 1);
    }
}