using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject[] prefabs;
    public string prefabTag;
    public float frequency;
    public int targetNum;
    public float top;
    public float bottom;

    private float startX;
    private float topY;
    private float bottomY;
    private Vector2 startPosition;
    private bool usePosition;
    private float lastSpawn = 0f;

    void Start()
    {
        startX = Camera.main.aspect * Camera.main.orthographicSize;
        if (Mathf.Approximately(top, bottom))
        {
            startPosition = new Vector2(startX, -Camera.main.orthographicSize + bottom);
            usePosition = true;
        }
        else
        {
            topY = (top - 0.5f) * Camera.main.orthographicSize * 2;
            bottomY = (bottom - 0.5f) * Camera.main.orthographicSize * 2;
            usePosition = false;
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag(prefabTag).Length < targetNum && 
            Random.value < Mathf.Pow(100000, frequency * lastSpawn - 1))
        {
            if (usePosition)
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], startPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector2(startX, Random.Range(bottomY, topY)), Quaternion.identity);
            }
            lastSpawn = 0;
        }
        else
        {
            lastSpawn += Time.deltaTime;
        }
    }

}
