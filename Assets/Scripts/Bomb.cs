using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;
    public GameObject turret;
    public float turretOffset;

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
                float explosionDistance = collision.contacts[0].point.x - tank.transform.position.x;

                Vector2 explosionPosition = new Vector2(collision.contacts[0].point.x,
                                                        tank.transform.position.y);
                Instantiate(explosion, explosionPosition, Quaternion.identity);

                Vector2 turretPosition = new Vector2(tank.transform.position.x,
                                                     tank.transform.position.y + turretOffset);
                GameObject newTurret = Instantiate(turret, turretPosition, Quaternion.identity);

                Rigidbody2D rb2d = newTurret.GetComponent<Rigidbody2D>();
                rb2d.velocity = tank.GetComponent<Rigidbody2D>().velocity;
                rb2d.AddForce(new Vector2(-explosionDistance / 4, 17 - Mathf.Abs(explosionDistance)), ForceMode2D.Impulse);
                rb2d.AddTorque(10 * explosionDistance, ForceMode2D.Impulse);

                Destroy(gameObject);
                Destroy(tank);
                destroyable.destroyed = true;
            }
        }
	}

}
