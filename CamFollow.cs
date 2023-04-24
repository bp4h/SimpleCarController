using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public float CamDistance;

    void Update()
    {
        cam.position = player.position + new Vector3(CamDistance, 10, 0);
    }
}

