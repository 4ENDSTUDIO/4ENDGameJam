using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Vector3 localScale;
    //private void Start()
    //{
    //    localScale = transform.localScale;
    //}
    // void Update()
    //{
    //    localScale.x = Player.healthAmount;
    //    transform.localScale = localScale;
    //}

    Image healthBar;
    float maxhealth = 100f;
    public static float health;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxhealth;
    }
    private void Update()
    {
        healthBar.fillAmount = health / maxhealth;
    }
}
