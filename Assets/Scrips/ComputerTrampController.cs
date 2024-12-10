using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrampController : MonoBehaviour
{
    public ScreamerController screamer;
    public PlayerMovement player;
    Animator _componentAnimator;
    public float time;
    public float qurrentTime;
    public float screamerTime;
    public float qurrentScreamerTime;
    private void Awake()
    {
        _componentAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        qurrentTime = time;
        qurrentScreamerTime = screamerTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && qurrentTime <= 0)
        {
            screamer.GetAudioScreamer();
            screamer.transform.localPosition = new Vector2(screamer.xPosition, screamer.maxY);
            player.playerQurrentLife = player.playerQurrentLife - 10;
            qurrentTime = time;
            qurrentScreamerTime = screamerTime;
        }
    }
    private void Update()
    {
        _componentAnimator.SetFloat("ScreamerTime", qurrentTime);
        qurrentTime = qurrentTime - Time.deltaTime;
        if (0 >= qurrentTime && qurrentScreamerTime <= 0)
        {
            qurrentTime = time;
        }
        qurrentScreamerTime = qurrentScreamerTime - Time.deltaTime;
        if (qurrentScreamerTime <= 0 && qurrentTime > 0)
        {
            qurrentScreamerTime = screamerTime;
        }
    }
}
