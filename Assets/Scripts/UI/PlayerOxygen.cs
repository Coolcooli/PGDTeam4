using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOxygen : MonoBehaviour
{
    [SerializeField]
    private float oxygen = 25f;
    [SerializeField]
    private float maxOxygen = 25f;
    [SerializeField]
    private float minOxygen = 0f;
    [SerializeField]
    private float oxygenCost = 1f;
    [SerializeField]
    private float oxygenRegen = 0.15f;

    private Player player;

    [SerializeField]
    private Image oxygenBar;
    [SerializeField] private AudioSource drownSound;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Update()
    {
        updateOxygen(player.IsInWater);
    }

    public void updateOxygen(bool inWater)
    {
        if (oxygenBar == null) return;

        if (inWater)
        {
            oxygen -= oxygenCost * Time.deltaTime;
        }
        else if (oxygen < maxOxygen)
        {
            drownSound.Stop();
            oxygen += oxygenRegen * Time.deltaTime;

        }

        if (oxygen < minOxygen)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (oxygen > maxOxygen)
        {
            oxygen = maxOxygen;
        }

        if(oxygen < maxOxygen / 5 && !drownSound.isPlaying)
            drownSound.Play();
        oxygenBar.fillAmount = (oxygen / maxOxygen);
    }
}
