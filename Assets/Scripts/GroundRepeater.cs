using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeater : MonoBehaviour
{

    private static float startX = 0;
    private float length;

    private void Awake()
    {
        if (transform.position.x < startX)
        {
            startX = transform.position.x;
        }
                       
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        length = collider.size.x * transform.localScale.x;
    }

    private void Update()
    {
        if (transform.position.x < (startX - length))
        {
            // Add 7 ground lengths
            Vector2 groundOffSet = new Vector2(length * 7f, 0);
            transform.position = (Vector2)transform.position + groundOffSet;
        }
    }

}
