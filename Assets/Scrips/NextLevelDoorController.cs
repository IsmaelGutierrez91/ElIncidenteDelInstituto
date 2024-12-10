using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoorController : MonoBehaviour
{
    public PlayerMovement player;
    public string sceneToLoad;
    public int rangeLvlToOpen;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.X) && player.keyRange >= rangeLvlToOpen)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
