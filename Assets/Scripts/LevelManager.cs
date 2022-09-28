using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace RPGUNDAV.Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        private string levelName;

        public List<GameObject> bonfires;
        public List<GameObject> coins;
        [SerializeField] TMP_Text coinText;
        [SerializeField] TMP_Text bombText;
        [SerializeField] TMP_Text keyText;

        private void Start()
        {
            levelName = SceneManager.GetActiveScene().name;
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
            coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
        }

        #region UPDATE_PLAYER_HUD
        public void Update(){
            coinText.text = "$ "+ GameManager.Instance.playerCoins;
            bombText.text = "B "+ GameManager.Instance.playerBombs;
            keyText.text = "K "+ GameManager.Instance.playerKeys;
        }

        public void AddCoinsToPlayer(int quantity){
            GameManager.Instance.playerCoins += quantity;
            PlayerPrefs.SetInt("coins", GameManager.Instance.playerCoins);
        }
        public int getPlayerCoins(){
            return GameManager.Instance.playerCoins;
        }

        public void AddBombsToPlayer(int quantity){
            GameManager.Instance.playerBombs += quantity;
            PlayerPrefs.SetInt("bombs", GameManager.Instance.playerBombs);
        }
        public int getPlayerBombs(){
            return GameManager.Instance.playerBombs;
        }

        public void AddKeysToPlayer(int quantity){
            GameManager.Instance.playerKeys += quantity;
            PlayerPrefs.SetInt("keys", GameManager.Instance.playerKeys);
        }
        public int getPlayerKeys(){
            return GameManager.Instance.playerKeys;
        }
        #endregion
    }
}