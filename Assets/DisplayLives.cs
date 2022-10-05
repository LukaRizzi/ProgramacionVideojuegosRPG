using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLives : MonoBehaviour
{
    [SerializeField] GameObject[] lives;

    public void AddHeart()
    {
        foreach (GameObject go in lives)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return;
            }
        }

        Debug.Log("Ten�s vida m�xima");
    }

    public void RemoveHeart()
    {
        foreach (GameObject go in lives)
        {
            if (go.activeSelf)
            {
                go.SetActive(false);
                return;
            }
        }

        Debug.Log("Deber�as estar muerto");
    }
}
