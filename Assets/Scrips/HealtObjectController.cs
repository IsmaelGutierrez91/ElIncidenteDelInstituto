using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtObjectController : MonoBehaviour
{
    public int objectHealt;
    public int PlayerHeald(int life)
    {
        life = life + objectHealt;
        return life;
    }

}
