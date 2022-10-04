using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerUsables : MonoBehaviour
    {
        public int startingBombs = 1;
        public int startingCoins = 1;
        public int startingKeys = 1;
        public GameObject bombPrefab;
        private Dictionary<PickUp, int> usables;
        private Transform playerTransform;
        private void Start(){
            playerTransform = this.GetComponentInParent<Transform>();
            usables = InitializeUsables();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) && usables[PickUp.BOMB] > 0){
                usables[PickUp.BOMB] = usables[PickUp.BOMB] - 1;
                PlayerPrefs.SetInt(PickUp.BOMB.ToString(), usables[PickUp.BOMB]);
                Instantiate(bombPrefab, playerTransform.position, Quaternion.identity); 
            }         
        }

        public int GetUsableCount(PickUp pickup){
            return usables[pickup];
        }

        public void AddUsable(PickUp pickup, int quantity){
            usables[pickup] += quantity;
            PlayerPrefs.SetInt(pickup.ToString(), usables[pickup]);
        }
        
        private Dictionary<PickUp, int> InitializeUsables(){
            usables = new Dictionary<PickUp, int>();
            usables.Add(PickUp.BOMB, 0);
            usables.Add(PickUp.COIN, 0);
            usables.Add(PickUp.KEY, 0);
            usables[PickUp.BOMB] = PlayerPrefs.GetInt(PickUp.BOMB.ToString(), startingBombs);
            usables[PickUp.COIN] = PlayerPrefs.GetInt(PickUp.COIN.ToString(), startingCoins);
            usables[PickUp.KEY] = PlayerPrefs.GetInt(PickUp.KEY.ToString(), startingKeys);
            return usables;
        }
    }
}