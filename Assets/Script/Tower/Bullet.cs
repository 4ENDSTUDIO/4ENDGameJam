using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("SLOWMO")]
    public float slowMotionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;
    

    [Header("Enviroment")]
    public GameObject shashEffect, point;
    [SerializeField]
    public GameObject Danger;
    public EnemyHealth healthbar;
    
   

    [Header("HealthBullet")]
    public float HitPoint;
    public float maxHitPoint = 3;

    public ScoreController score;
   
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
            score.currentScore += 3;
            Instantiate(shashEffect, transform.position, Quaternion.identity);
            if (shashEffect == true)
            {
                Instantiate(point, transform.position, Quaternion.identity);
            }

           


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag =="Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag =="Swor")
        {
            takeHit(1);
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startSlowMo();
        }
        if (collision.gameObject.tag == "DIE")
        {
            Destroy(gameObject);
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
        Danger.SetActive(true);
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
    }
    void stopSlowmo()
    {
        Danger.SetActive(false);
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
  





}
