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

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Update()
    {
        UpdateOxygen(player.IsInWater);
    }

    public void UpdateOxygen(bool inWater)
    {
        if (oxygenBar == null) return;

        if (inWater)
        {
            oxygen -= oxygenCost * Time.deltaTime;
        }
        else if (oxygen < maxOxygen)
        {
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

        oxygenBar.fillAmount = (oxygen / maxOxygen);
    }
}
