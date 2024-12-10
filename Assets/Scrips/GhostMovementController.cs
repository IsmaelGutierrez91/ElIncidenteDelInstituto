using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovementController : MonoBehaviour
{
    public float maxY;
    public float minY;
    public int direction;
    public float speed;
    Rigidbody2D _ComponentRigidbody2D;
    public EnemyVisionRange enemigoinfo;
    public bool iCanSeeThePlayer;
    // Start is called before the first frame update
    void Awake()
    {
        _ComponentRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        iCanSeeThePlayer = enemigoinfo.iCanSeeThePlayer;
        if (iCanSeeThePlayer == true)
        {
            direction = -1;
        }

        if (_ComponentRigidbody2D.transform.position.y > maxY)
        {
            direction = -1;
        }
        if (_ComponentRigidbody2D.transform.position.y < minY)
        {
            direction = 1;
        }
        _ComponentRigidbody2D.transform.position = new Vector2(_ComponentRigidbody2D.transform.position.x, _ComponentRigidbody2D.transform.position.y + direction * speed * Time.deltaTime);
    }
}
