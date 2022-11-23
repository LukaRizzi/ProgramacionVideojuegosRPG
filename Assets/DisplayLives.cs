using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV
{
    public class DisplayLives : MonoBehaviour
    {
        [SerializeField] GameObject[] lives;

        public void UpdateHearts(int number)
        {
            int i = 0;
            foreach (GameObject go in lives)
            {
                go.SetActive(i < number);
                i++;
            }
        }
    }
}