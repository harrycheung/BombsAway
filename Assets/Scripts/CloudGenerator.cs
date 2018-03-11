using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public static CloudGenerator instance;

    public GameObject cloud;
    public float cloudFrequency = 0.25f;
    public float cloudRegion = 0.65f;
    public int targetNumOfClouds = 6;
    public int numOfClouds = 0;

    private float startX = 0f;
    private float topY = 0f;
    private float bottomY = 0f;
    private float lastCloudSpawn = 0f;

	void Awake()
	{
        instance = this;
	}

	void Start()
    {
        startX = Camera.main.pixelWidth +
                       (cloud.GetComponent<Renderer>().bounds.size.x * GameController.instance.PixelRatio()) / 2;
        topY = Camera.main.pixelHeight;
        bottomY = (1 - cloudRegion) * topY;
	}

	void Update()
    {        
        if (numOfClouds < targetNumOfClouds && Random.value < Mathf.Pow(100000, cloudFrequency * lastCloudSpawn - 1))
        {
            Debug.Log(lastCloudSpawn);
            //Debug.Log(cloudFrequency * lastCloudSpawn - 1);
            //Debug.Log(Mathf.Pow(1000, cloudFrequency * lastCloudSpawn - 1));
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(startX, Random.Range(bottomY, topY), 0));
            Instantiate(cloud, new Vector2(position.x, position.y), Quaternion.identity);
            lastCloudSpawn = 0;
            numOfClouds++;
        }
        else
        {
            lastCloudSpawn += Time.deltaTime;
        }
    }

}
