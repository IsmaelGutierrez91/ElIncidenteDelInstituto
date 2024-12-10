using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyVisionRange : MonoBehaviour
{

    public AudioSource sfx;
    public bool iCanSeeThePlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sfx.Play();
            iCanSeeThePlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            iCanSeeThePlayer = false;
        }
    }
}
