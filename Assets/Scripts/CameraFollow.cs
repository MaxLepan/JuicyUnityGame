using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothFactor = 0.45f;

    Vector3 smoothPosition = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        smoothPosition = Vector3.Lerp(smoothPosition, player.position, smoothFactor);
        transform.position = smoothPosition + offset;
    }
}
