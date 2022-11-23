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

        [HideInInspector] public GameObject player;
        [HideInInspector] public PlayerUsables playerUsables;

        private void Start()
        {
            levelName = SceneManager.GetActiveScene().name;
            bonfires = GameObject.FindGameObjectsWithTag("Bonfire").ToList();
            player = GameObject.FindGameObjectWithTag("Player");
            playerUsables = player.GetComponent<PlayerUsables>();
        }

        #region UPDATE_PLAYER_HUD
        public void Update(){
            coinText.text = playerUsables.GetUsableCount(PickUp.COIN).ToString();
            bombText.text = playerUsables.GetUsableCount(PickUp.BOMB).ToString();
            keyText.text = playerUsables.GetUsableCount(PickUp.KEY).ToString();
        }

        public void AddPickUpToPlayer(PickUp pickup, int quantity){
            if (pickup != PickUp.HEART)
                playerUsables.AddUsable(pickup, quantity);
            else
                player.GetComponent<PlayerHPManager>().Hp++;

        }
        #endregion
    }
}