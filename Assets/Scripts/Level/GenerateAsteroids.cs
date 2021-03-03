using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour {

	[SerializeField]
	GameObject[] typeAsteroid;

	[SerializeField]
	public float SpawnTime=2f;

    [SerializeField]
	public bool Spawning=true;

	public int AsteroidLevel{ get; set; }
	public int AsteroidRange{ get; set; }


	// Use this for initialization
	void Start () {
		AsteroidLevel = 0;
		AsteroidRange = 4;
		StartCoroutine (SpawnCoroutine ());
	}

	IEnumerator SpawnCoroutine()
	{
		while (true) 
		{
			while (Spawning) {
				SpawnAsteroids ();

				yield return new WaitForSeconds (SpawnTime);
			}
			yield return new WaitForEndOfFrame ();
		}
		
	}
	private int RandomType()
	{
		var index = AsteroidLevel +  Random.Range (-AsteroidRange, AsteroidRange);
		index = Mathf.Clamp (index, 0, typeAsteroid.Length-1);
        Debug.Log(index);
        return index;
	}

	private void SpawnAsteroids()
	{
        var asteroidType = RandomType();
        var obj=Instantiate (typeAsteroid[asteroidType], transform.position, Quaternion.identity);
		obj.transform.position += Vector3.right * Random.Range (-2f, 2f);
	}
}
