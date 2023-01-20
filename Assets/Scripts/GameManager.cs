using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int deathCount = 0;
    public void PlayerDeath()
    {
        StartCoroutine(PlayerRespawn());
    }

    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
