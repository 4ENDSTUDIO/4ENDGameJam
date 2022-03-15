using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;

    private Rigidbody2D rig;

    [Header("Scoring")]
    public ScoreController score;
    public float scoringRatio;
    private float lastPositionX;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lastPositionX = transform.position.x;
    }
    private void FixedUpdate()
    {
        Vector2 velocityvector = rig.velocity;
        velocityvector.x = Mathf.Clamp(velocityvector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);
        rig.velocity = velocityvector;
    }
    private void Update()
    {
        int distancePassed = Mathf.FloorToInt(transform.position.x - lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if(scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            lastPositionX += distancePassed;
        }
    }
   


}
