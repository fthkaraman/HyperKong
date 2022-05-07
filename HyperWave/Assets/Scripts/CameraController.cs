using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 4.4f;
        transform.position = targetPos;
    }
}
