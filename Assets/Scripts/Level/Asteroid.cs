using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]


public class Asteroid : MonoBehaviour {

	[SerializeField]
	private float Strenght = 6f;

    [SerializeField]
     private int Money = 10;

    [SerializeField]
    private int Points;

    [SerializeField]
	GameObject DestroyingParticles;

	[SerializeField]
	GameObject DestroyParticles;

	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		SpeedAsteroid ();
	}


	private void SpeedAsteroid()
	{
        var targetSpeed = Random.Range(2f,4f);
		GetComponent<Rigidbody2D> ().velocity = Vector3.down * targetSpeed;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var obj=other.gameObject;
		var bullet=obj.GetComponent<Bullet>();

		if (bullet != null && bullet.tag!="Bullet") {
			GenerateParticle (DestroyingParticles, other.transform.position);

			Strenght-=bullet.Power;
			Destroy (obj);

			if (Strenght <= 0) {
				GenerateParticle (DestroyingParticles, other.transform.position);
				FindObjectOfType<GameManager> ().Money += Money;
                FindObjectOfType<GameManager>().Points += Points;
                //FindObjectOfType<QuestCounter>().CounterDestroyedAsteroids += 1;
				Destroy (gameObject);
			}
		}
	}

	private void GenerateParticle(GameObject prefab, Vector3 position)
	{
		var particles=Instantiate (prefab, position, Quaternion.identity);
		particles.GetComponent<ParticleSystemRenderer> ().material.mainTexture = spriteRenderer.sprite.texture;

	}
}
