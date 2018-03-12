using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuneGenerator : MonoBehaviour
{

    public static DuneGenerator instance;

    public GameObject[] dunes;
    public float duneFrequency = 0.2f;
    public int targetNumOfDunes = 3;
    public int numOfDunes = 0;

    private Vector2 startPosition;
    private float lastDuneSpawn = 0f;
    private int groundHeight = 12; // in pixels

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Vector2 duneSize = dunes[0].GetComponent<Renderer>().bounds.size;
        float pixelRatio = GameController.instance.PixelRatio();
        float startX = Camera.main.pixelWidth + (duneSize.x * pixelRatio) / 2;
        float startY = groundHeight * pixelRatio + (duneSize.y * pixelRatio) / 2;
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(startX, startY, 0));
        startPosition = new Vector2(position.x, position.y);
        Debug.Log(startPosition);
    }

    void Update()
    {
        if (numOfDunes < targetNumOfDunes && Random.value < Mathf.Pow(100000, duneFrequency * lastDuneSpawn - 1))
        {
            Instantiate(dunes[Random.Range(0, dunes.Length)], startPosition, Quaternion.identity);
            lastDuneSpawn = 0;
            numOfDunes++;
        }
        else
        {
            lastDuneSpawn += Time.deltaTime;
        }
    }

}
