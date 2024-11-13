using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player = null;
    public Vector3 offset = new Vector3(3, 7, -4);

    Vector3 pos = Vector3.zero;

    void Update()
    {
        pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
        gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
    }
}
