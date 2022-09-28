using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] Vector3 newPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.newPos = newPos;
            SceneManager.LoadScene(sceneName);
        }
    }
}
