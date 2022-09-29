using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGUNDAV.Gameplay{
    public class ExplosiveBehaviour : MonoBehaviour
    {
        public float timeTillExplosion;
        public float explosionRadius;
        public int damageToEnemies;
        public int damageToPlayer;
        private CircleCollider2D bombCollider;
        private float timeAtActivation;
        // Logica incompleta terminar explosion
        void Start()
        {
            bombCollider = GetComponentInParent<CircleCollider2D>();
            timeAtActivation = Time.deltaTime;
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.deltaTime - timeAtActivation >= timeTillExplosion){
                bombCollider.radius = explosionRadius;
                bombCollider.isTrigger = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("PlayerHurtBox")){
                other.GetComponent<PlayerStateManager>().Attacked(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}