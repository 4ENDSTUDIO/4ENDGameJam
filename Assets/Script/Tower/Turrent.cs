using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject GUN;

    [Header("FIRE")]
    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform ShootPoint;
    public float Force;

    [Header("Position")]
    public Transform player;
    public float horizontalOffset;
    // Update is called once per frame
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x + horizontalOffset;
        transform.position = newPosition;

        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                    
                }
            }
        }
        if(Detected)
        {
            GUN.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
       GameObject BulletIns =  Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
