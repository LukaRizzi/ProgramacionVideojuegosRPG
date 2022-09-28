using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPGUNDAV.Gameplay
{
    public class PlayerStateResting : PlayerState
    {
        public override void StartState(PlayerStateManager manager)
        {
            manager.hpManager.Hp = manager.hpManager.hpMax;
            manager.animator.SetBool("walking", false);
            manager.animator.SetBool("resting", true);
            manager.rb.velocity = Vector2.zero;
            manager.swordHolder.gameObject.SetActive(false);

            PlayerPrefs.SetString("saveSpotScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("saveSpotX", manager.transform.position.x);
            PlayerPrefs.SetFloat("saveSpotY", manager.transform.position.y);
        }

        public override void UpdateState(PlayerStateManager manager)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.animator.SetBool("resting", false);
                manager.ChangeState(new PlayerStateWalking());
            }
        }

        public override void OnAttacked(PlayerStateManager manager, GameObject enemy)
        {

        }
    }
}