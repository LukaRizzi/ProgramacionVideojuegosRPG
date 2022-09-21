using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace RPGUNDAV.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        public List<GameObject> bonfires;
        [SerializeField] TMP_Text coinText;
        [SerializeField] int playerCoins = 0;

        private void Start()
        {
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
        }

        public void Update(){
            coinText.text = "$ "+playerCoins;
        }
        public void AddCoinsToPlayer(int quantity){
            playerCoins += quantity;
        }
        public int getPlayerCoins(){
            return playerCoins;
        }
    }
}