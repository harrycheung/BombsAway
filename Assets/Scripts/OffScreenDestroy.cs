using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenDestroy : MonoBehaviour
{

    public float width;

    private float leftEdge;

	void Start()
	{
        leftEdge = -(Camera.main.aspect * Camera.main.orthographicSize);
	}

	void Update()
    {
        if (transform.position.x + width < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}
