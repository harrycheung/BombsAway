using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBay : MonoBehaviour
{

    public Rigidbody2D bomb;

    private float nextDrop = 0f;

	void Awake()
	{
        nextDrop = Time.time - GameController.instance.dropRate;
	}

	void Start()
    {
        Input.simulateMouseWithTouches = true;
	}
	
	void Update()
    {            
        if (Input.GetMouseButton(0) && Time.time > nextDrop)
        {
            DropBomb();
        }

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && Time.time > nextDrop)
            {
                DropBomb();
            }
        }
	}

    private void DropBomb()
    {
        Instantiate(bomb, transform.position, transform.rotation);
        nextDrop = Time.time + GameController.instance.dropRate;
    }

}
