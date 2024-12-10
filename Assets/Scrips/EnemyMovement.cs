using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    SpriteRenderer _ComponentSpriteRenderer;
    public EnemyVisionRange enemigoinfo;
    Rigidbody2D _ComponentRigidbody2D;
    public int enemyDirection;
    public float enemySpeed;
    public float enemyMaxSpeed;
    public float enemyMinSpeed;
    public float maxX;
    public float minX;
    public bool iCanSeeThePlayer;
    public GameObject visonRange;
    private void Awake()
    {
        _ComponentRigidbody2D = GetComponent<Rigidbody2D>();
        _ComponentSpriteRenderer = GetComponent<SpriteRenderer>();
        enemySpeed = enemyMinSpeed;
    }
    private void Update()
    {
        if(iCanSeeThePlayer == false)
        {
            enemySpeed = enemyMaxSpeed;
        }
        if (iCanSeeThePlayer == true)
        {
            enemySpeed = enemyMinSpeed;
        }
        if (enemyDirection == 1)
        {
            visonRange.transform.position = new Vector2(this.gameObject.transform.position.x + 2.61f, visonRange.transform.position.y);
            _ComponentSpriteRenderer.flipX = false;
        }
        if (enemyDirection == -1)
        {
            visonRange.transform.position = new Vector2(this.gameObject.transform.position.x - 2.61f, visonRange.transform.position.y);
            _ComponentSpriteRenderer.flipX = true;
        }
        if (_ComponentRigidbody2D.position.x < minX)
        {
            enemyDirection = 1;
        }
        if (_ComponentRigidbody2D.position.x > maxX)
        {
            enemyDirection = -1;
        }
        iCanSeeThePlayer = enemigoinfo.iCanSeeThePlayer;
    }
    static int GetNewDirection()
    {
        int newDirection = Random.Range(1, 3);
        if (newDirection < 2)
        {
            newDirection = 1;
        }else
        {
            newDirection = -1;
        }
        return newDirection;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ChangeDirection" && iCanSeeThePlayer == false)
        {
            enemyDirection = GetNewDirection();
        }
    }
    void FixedUpdate()
    {
        _ComponentRigidbody2D.velocity = new Vector2(enemyDirection * enemySpeed, _ComponentRigidbody2D.velocity.y);
    }
}
