using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public bool gameOver;
    public float dropRate;

	void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
	}

    public float PixelRatio()
    {
        return Screen.height / (2 * Camera.main.orthographicSize);
    }

}
