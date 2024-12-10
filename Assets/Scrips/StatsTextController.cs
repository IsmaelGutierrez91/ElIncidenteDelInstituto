using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextController : MonoBehaviour
{
    Text text;
    public string playerInfoUpdate;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfoUpdate == "Keys")
        {
            text.text = "X " + playerMovement.keyRange;
        }
        if (playerInfoUpdate == "Life")
        {
            text.text = playerMovement.playerQurrentLife.ToString();
        }
        if (playerInfoUpdate == "Stamina")
        {
            text.text = (Mathf.Ceil(playerMovement.qurrentStamina)).ToString();
        }
    }
}
