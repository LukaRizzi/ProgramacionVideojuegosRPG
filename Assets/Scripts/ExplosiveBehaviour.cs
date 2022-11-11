using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace RPGUNDAV.Gameplay
{
    public class ExplosiveBehaviour : MonoBehaviour
    {
        public float timeTillExplosion;
        public float explosionDuration;
        public Vector2 explosionDistance;
        public Sprite visibleReachShape;
        private BoxCollider2D bombCollider;
        private float timeAtActivation;
        private Animator animator;
        private GameObject visibleReach;

        void Start()
        {
            bombCollider = GetComponentInParent<BoxCollider2D>();
            animator = GetComponentInParent<Animator>();
            timeAtActivation = Time.fixedTime;
            bombCollider.enabled = false;
            animator.speed = 1/timeTillExplosion;
            visibleReach = new GameObject();
            visibleReach.AddComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Time.fixedTime >= timeAtActivation + timeTillExplosion){
                bombCollider.enabled = true;
                bombCollider.size = explosionDistance;

                CreateVisibleReach();
                if(Time.fixedTime >= timeAtActivation + timeTillExplosion + explosionDuration){
                    Destroy(visibleReach);
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerHurtBox"))
            {
                GameObject playerHurtBox = other.gameObject;
                playerHurtBox.GetComponentInParent<PlayerStateManager>().Attacked(this.gameObject);
            }

            if (other.gameObject.layer == 7) //7 es EnemyLayer
            {
                EnemyStateManager enemyManager = other.GetComponent<EnemyStateManager>();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                enemyManager.Attacked(this.gameObject);
            }

            if (other.gameObject.CompareTag("Destructible")){
                Destroy(other.gameObject);
            }
        }


        /*void OnCollisionEnter2D(Collision2D collision){

            Debug.Log(collision.gameObject);
            if (collision.gameObject.CompareTag("Destructible")){
                Tilemap tilemap = collision.gameObject.GetComponentInParent<Tilemap>();
                Vector3 hitPosition = Vector3.zero;
                foreach (ContactPoint2D hit in collision.contacts)
                {
                    hitPosition.x = hit.point.x * hit.normal.x;
                    hitPosition.y = hit.point.y * hit.normal.y;
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                }
            }
        }*/

        private void CreateVisibleReach(){
            Transform visibleReachTF = visibleReach.GetComponent<Transform>();
            SpriteRenderer sr = visibleReach.GetComponent<SpriteRenderer>();
            visibleReachTF.position = this.gameObject.transform.position;
            visibleReachTF.localScale = new Vector3(explosionDistance.x,explosionDistance.y, 0f);
            sr.sprite = visibleReachShape;
            sr.color = new Color(1,0,0,0.7f);
        }
    }
}