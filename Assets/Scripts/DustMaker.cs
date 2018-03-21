using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustMaker : MonoBehaviour
{

    public GameObject dustFX;

	void OnCollisionEnter2D(Collision2D collision)
	{
        GameObject dust = Instantiate(dustFX, collision.contacts[0].point, Quaternion.identity);
        Destroy(dust, dust.GetComponent<ParticleSystem>().main.duration);
	}

}
