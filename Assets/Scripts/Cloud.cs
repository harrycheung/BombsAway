using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private float halfCloudWidth = 0f;

    void Start()
    {
        halfCloudWidth = (GetComponent<Renderer>().bounds.size.x * GameController.instance.PixelRatio()) / 2;
    }
        
	void Update()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        if (position.x + halfCloudWidth < 0)
        {
            Destroy(gameObject);
        }
	}

}
