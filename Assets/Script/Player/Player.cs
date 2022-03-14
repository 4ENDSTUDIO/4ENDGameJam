using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;

    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 velocityvector = rig.velocity;
        velocityvector.x = Mathf.Clamp(velocityvector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);
        rig.velocity = velocityvector;
    }
}
