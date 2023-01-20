using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;

    private SpriteRenderer sr;

    private void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            sr.enabled = false;
            gm.PlayerDeath();
        }
    }
}
