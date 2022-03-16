using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Vector3 localScale;
    private void Start()
    {
        localScale = transform.localScale;
    }
    private void Update()
    {
        localScale.x = Player.healthAmount;
        transform.localScale = localScale;
    }
}
