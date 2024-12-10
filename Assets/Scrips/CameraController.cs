using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objetive;
    public float minXPosition;
    public float maxXPosition;
    void Update()
    {
        if (objetive != null)
        {
            float positionX = Mathf.Clamp(objetive.transform.position.x, minXPosition, maxXPosition);
            transform.position = new Vector3(positionX, 0, -10);
        }
    }
}
