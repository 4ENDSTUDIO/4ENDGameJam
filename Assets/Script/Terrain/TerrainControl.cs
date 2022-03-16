using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainControl : MonoBehaviour
{

    private const float debugLineHeight = 10.0f;
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position + new Vector3(6,2) * debugLineHeight / 2, transform.position + new Vector3(6,-2) * debugLineHeight / 2, Color.green);
    }
}
