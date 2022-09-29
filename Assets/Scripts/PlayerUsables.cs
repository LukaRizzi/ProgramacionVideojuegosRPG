using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay
{
    public class PlayerUsables : MonoBehaviour
    {
        Dictionary<PickUp, int> usables;
        // Hacer pasaje completo quien maneja la cantidad de pickupables que tiene el jugador. Esta clase deberia manejarlo
        // la clase de gamemanager deberia consultar a esta para luego actualizar el HUD.
        
        public GameObject bombPrefab;

        private Transform playerTransform;
        private void Start(){
            usables = new Dictionary<PickUp, int>();
            usables.Add(PickUp.BOMB, 10);
            usables.Add(PickUp.COIN, 1);
            usables.Add(PickUp.KEY, 1);
            playerTransform = this.GetComponentInParent<Transform>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) && usables[PickUp.BOMB] > 0){
                usables[PickUp.BOMB] = usables[PickUp.BOMB] - 1;
                Instantiate(bombPrefab, playerTransform.position, Quaternion.identity);
            }
                
        }
    }
}