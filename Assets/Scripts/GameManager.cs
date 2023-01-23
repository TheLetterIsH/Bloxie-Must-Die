using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Instance of game manager which can be called through other scripts
    public static GameManager instance;

    // Variables
    public int deathCount;
    public bool bloxCollected = false;
    public int totalBloxCount;

    // Icon for point
    public GameObject bloxIcon;

    // Death text
    public TMP_Text deathText;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        // Getting the saved value of death count and displaying it at the start of the game
        deathCount = PlayerPrefs.GetInt("deathCount");
        deathText.text = deathCount.ToString();
    }

    public void PlayerDeath()
    {
        // Increasing death count by 1 and displaying it
        deathCount += 1;
        deathText.text = deathCount.ToString();

        // Setting the new death count
        PlayerPrefs.SetInt("deathCount", deathCount);
        
        //Coroutine for respawning the player
        StartCoroutine(PlayerRespawn());
    }

    IEnumerator PlayerRespawn()
    {
        // Waiting for 1s and then loading the current scene, i.e, respawning
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BloxCollected()
    {
        // setting bool of blox collected to true, displaying blox icon on the screen and also incrementing the total blox count
        bloxCollected = true;
        bloxIcon.SetActive(true);
        totalBloxCount += 1;
    }
}
