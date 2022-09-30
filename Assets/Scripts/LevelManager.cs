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
        [SerializeField] TMP_Text coinText;
        [SerializeField] TMP_Text bombText;
        [SerializeField] TMP_Text keyText;

        private void Start()
        {
            levelName = SceneManager.GetActiveScene().name;
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
        }

        #region UPDATE_PLAYER_HUD
        public void Update(){
            coinText.text = ""+GameManager.Instance.playerCoins;
            bombText.text = ""+ GameManager.Instance.playerBombs;
            keyText.text = ""+ GameManager.Instance.playerKeys;
        }

        public void AddPickUpToPlayer(PickUp pickup, int quantity){
            switch(pickup){
                case PickUp.BOMB:
                    GameManager.Instance.playerBombs += quantity;
                    PlayerPrefs.SetInt("bombs", GameManager.Instance.playerBombs);
                    break;
                case PickUp.COIN:
                    GameManager.Instance.playerCoins += quantity;
                    PlayerPrefs.SetInt("coins", GameManager.Instance.playerCoins);
                    break;
                case PickUp.KEY:
                    GameManager.Instance.playerKeys += quantity;
                    PlayerPrefs.SetInt("keys", GameManager.Instance.playerKeys);
                    break;
                default:
                    break;
            }
        }
        public int getPlayerCoins(){
            return GameManager.Instance.playerCoins;
        }
        public int getPlayerBombs(){
            return GameManager.Instance.playerBombs;
        }
        public int getPlayerKeys(){
            return GameManager.Instance.playerKeys;
        }
        #endregion
    }
}