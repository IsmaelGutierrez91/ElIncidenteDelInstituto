using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject key;
    public int lvlToOpen;
    Transform _componentTransform;
    private void Awake()
    {
        _componentTransform = GetComponent<Transform>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.keyRange == lvlToOpen && Input.GetKeyDown(KeyCode.X))
        {
            key.transform.position = new Vector2(_componentTransform.position.x, _componentTransform.position.y);
        }
    }
}
