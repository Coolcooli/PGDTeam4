using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    TMP_Text depth;

    [SerializeField]
    private int waterLevel = 100;

    // Start is called before the first frame update
    void Start()
    {
        GetDepth();
    }

    // Update is called once per frame
    void Update()
    {
        GetDepth();
    }

    private void GetDepth()
    {
        float depthFloat = waterLevel - player.transform.position.y;

        depth.text = Mathf.CeilToInt(depthFloat).ToString() + "M";
    }
}
