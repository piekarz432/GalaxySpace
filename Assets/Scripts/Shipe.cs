using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Shipe : MonoBehaviour {

    public event System.Action ShipDestroyed;

	private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.GetComponent<Asteroid>())
        {
            var asteroid = other.gameObject.GetComponent<Asteroid>();

            if (asteroid == null)
            {
                return;
            }
            Destroy(other.gameObject);

            if (ShipDestroyed != null)
            {
                ShipDestroyed.Invoke();
            }
            
        }

        if(other.gameObject.tag=="Bullet")
        {
            var bullet = other.gameObject.GetComponent<Bullet>();

            if (bullet == null)
            {
                return;
            }
            Destroy(bullet.gameObject);

            if (ShipDestroyed != null)
            {
                ShipDestroyed.Invoke();
            }
           
        }
        
	}
}
