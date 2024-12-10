using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyController : MonoBehaviour
{
    Transform _componentTransform;
    public float distancia;
    float minY;
    float maxY;
    public PlayerMovement player;
    private void Awake()
    {
        _componentTransform = GetComponent<Transform>();
        minY = _componentTransform.localPosition.y;
        maxY = _componentTransform.localPosition.y + distancia;
    }
    private void Update()
    {
        if (player.canDie == true)
        {
            _componentTransform.localPosition = new Vector2(_componentTransform.localPosition.x, minY);
        }
        if (player.canDie == false)
        {
            _componentTransform.localPosition = new Vector2(_componentTransform.localPosition.x, maxY);

        }
    }
}
