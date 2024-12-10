using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int keyLevel;
    Transform _componentTransform;
    public GameObject keyInHud;
    float xPosition;
    public PlayerMovement player;
    void Awake()
    {
        _componentTransform = GetComponent<Transform>();
    }
    void Start()
    {
        xPosition = keyInHud.transform.localPosition.x;
        keyInHud.transform.localPosition = new Vector2(keyInHud.transform.localPosition.x + 100, keyInHud.transform.localPosition.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { 
            player.keyRange = keyLevel;
            keyInHud.transform.localPosition = new Vector2(xPosition, keyInHud.transform.localPosition.y);
            Destroy(this.gameObject);
        }
    }
}
