using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gm;

    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        sr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            sr.enabled = false;
            rb.simulated = false;
            GameManager.instance.PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blox"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameManager.instance.BloxCollected();
        }
    }
}
