using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dune : MonoBehaviour
{

    private float halfDuneWidth = 0f;

    void Start()
    {
        halfDuneWidth = (GetComponent<Renderer>().bounds.size.x * GameController.instance.PixelRatio()) / 2;
    }

    void Update()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        if (position.x + halfDuneWidth < 0)
        {
            Destroy(gameObject);
        }
    }

}
