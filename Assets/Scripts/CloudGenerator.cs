using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    public Rigidbody2D cloud;
    public float cloudFrequency = 0.005f;
    public float cloudRegion = 0.65f;

    private float halfCloudWidth = 0f;
    private float cameraWidth = 0f;
    private float cameraHeight = 0f;

	void Start()
    {
        halfCloudWidth = (cloud.GetComponent<Renderer>().bounds.size.x * GameController.instance.PixelRatio()) / 2;
        cameraWidth = Camera.main.pixelWidth;
        cameraHeight = Camera.main.pixelHeight;
	}

	void Update()
    {
        if (Random.value < cloudFrequency)
        {
            float x = cameraWidth + halfCloudWidth;
            float y = Random.value * cloudRegion * cameraHeight + (1 - cloudRegion) * cameraHeight;
            // ScreenToWorldPoint set Z to the camera's Z, which hides the cloud.
            // We pull out the x and y values in this hacky way to solve this.
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            Instantiate(cloud, new Vector3(position.x, position.y, 0), Quaternion.identity);
        }
    }

}
