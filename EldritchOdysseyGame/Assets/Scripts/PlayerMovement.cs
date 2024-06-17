using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnStartLocalPlayer()
    {
        if (Camera.main != null)
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    
    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = direction * speed;

    }
}
