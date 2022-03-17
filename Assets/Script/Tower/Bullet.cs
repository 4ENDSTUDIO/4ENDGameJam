using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("SLOWMO")]
    public float slowMotionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;


    public GameObject shashEffect;
    public EnemyHealth healthbar;

    [Header("HealthBullet")]
    public float HitPoint;
    public float maxHitPoint = 3;
    
   
    void Start()
    {
        HitPoint = maxHitPoint;
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
        healthbar.SetHealth(HitPoint, maxHitPoint);
    }
    public void takeHit(float damage)
    {
        HitPoint -= damage;
        healthbar.SetHealth(HitPoint, maxHitPoint);
        if (HitPoint <= 0 )
        {
            Destroy(gameObject);
            Instantiate(shashEffect, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startSlowMo();
        }
      

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stopSlowmo();
        }
    }
    void startSlowMo()
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
    }
    void stopSlowmo()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
    private void OnMouseDown()
    {
        takeHit(1);
       


    }






}
