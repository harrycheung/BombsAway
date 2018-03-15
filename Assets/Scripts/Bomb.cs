using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;
    public GameObject staticTank;
    public float tankOffset;

	void Update()
    {
        Quaternion target = Quaternion.Euler(0, 0, -90);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime / 2);
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Tank")
        {
            GameObject tank = collision.collider.gameObject;
            Destroyable destroyable = tank.GetComponent<Destroyable>();

            if (!destroyable.destroyed)
            {
                Vector2 explosionPosition = new Vector2(collision.contacts[0].point.x,
                                                        tank.transform.position.y);
                Instantiate(explosion, explosionPosition, Quaternion.identity);

                 
                GameObject newTank = Instantiate(staticTank, 
                                                 new Vector2(tank.transform.position.x, 
                                                             tank.transform.position.y + tankOffset), 
                                                 Quaternion.identity);
                foreach (Transform child in newTank.transform)
                {
                    float explosionDistance = collision.contacts[0].point.x - child.position.x;

                    Rigidbody2D rb2d = child.gameObject.GetComponent<Rigidbody2D>();
                    rb2d.velocity = tank.GetComponent<Rigidbody2D>().velocity;
                    rb2d.AddForce(new Vector2(-explosionDistance / 4, 
                                              25 - Mathf.Abs(explosionDistance)), 
                                  ForceMode2D.Impulse);
                    rb2d.AddTorque((explosionDistance < 0 ? -20 : 20) *
                                   Mathf.Pow(0.9f, Mathf.Round(Mathf.Abs(explosionDistance / 5))),
                                   ForceMode2D.Impulse);
                }

                Destroy(gameObject);
                Destroy(tank);
                destroyable.destroyed = true;
            }
        }
	}

}
