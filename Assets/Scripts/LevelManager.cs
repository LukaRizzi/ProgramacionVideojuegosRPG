using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public List<GameObject> bonfires;

        private void Start()
        {
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
        }
    }
}