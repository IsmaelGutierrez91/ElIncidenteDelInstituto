using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class ScreamerController : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float xPosition;
    public float screamerTime;
    public float qurrentTime;
    Transform _componentTransform;
    public AudioSource screamer1;
    public AudioSource screamer2;
    private void Awake()
    {
        _componentTransform = GetComponent<Transform>();
    }
    private void Start()
    {
        xPosition = _componentTransform.localPosition.x;
        maxY = _componentTransform.localPosition.y;
        _componentTransform.position = new Vector2(_componentTransform.localPosition.x, _componentTransform.localPosition.y - 1000);
        minY = _componentTransform.localPosition.y;
    }
    private void Update()
    {
        if(_componentTransform.localPosition.y <= minY)
        {
            qurrentTime = screamerTime;
        }
        if (_componentTransform.localPosition.y > minY)
        {
            qurrentTime = qurrentTime - Time.deltaTime;
        }
        if (qurrentTime < 0)
        {
            _componentTransform.localPosition = new Vector2 (xPosition, minY);
        }
    }
    public void GetAudioScreamer()
    {
        int audioToPlay = Random.Range(1, 3);
        if (audioToPlay >= 2)
        {
            screamer1.Play();
        }
        else
        {
            screamer2.Play();
        }
    }
}
