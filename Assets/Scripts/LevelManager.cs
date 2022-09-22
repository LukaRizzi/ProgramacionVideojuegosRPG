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
        [SerializeField] TMP_Text bombText;
        [SerializeField] TMP_Text keyText;
        [SerializeField] int playerCoins = 0;
        [SerializeField] int playerBombs = 0;
        [SerializeField] int playerKeys = 0;

        private void Start()
        {
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
        }

        public void Update(){
            coinText.text = "$ "+playerCoins;
            bombText.text = "B "+playerBombs;
            keyText.text = "K "+playerKeys;
        }
        public void AddCoinsToPlayer(int quantity){
            playerCoins += quantity;
        }
        public int getPlayerCoins(){
            return playerCoins;
        }

        public void AddBombsToPlayer(int quantity){
            playerBombs += quantity;
        }
        public int getPlayerBombs(){
            return playerBombs;
        }

        public void AddKeysToPlayer(int quantity){
            playerKeys += quantity;
        }
        public int getPlayerKeys(){
            return playerKeys;
        }
    }
}