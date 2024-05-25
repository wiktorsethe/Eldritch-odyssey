using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraMovement : NetworkBehaviour
{
    private Camera cam;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Vector3 desiredPosition = transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(cam.transform.position, desiredPosition, smoothSpeed);
        cam.transform.position = smoothedPosition;
    }
}
