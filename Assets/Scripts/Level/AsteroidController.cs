using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AsteroidController : MonoBehaviour {

	public int CurrentSpawnNumber{ get; private set; }

	public event System.Action<int> AsteroidSpawnStart;
	public event System.Action<int> AsteroidSpawnEnd;

    [SerializeField]
    GameObject Boos0bject;

    [SerializeField]
    AudioClip BossClip;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
		CurrentSpawnNumber = 1;
		StartCoroutine (AsteroidCoroutine ());
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BossClip;
	}
	
	private IEnumerator AsteroidCoroutine()
	{
		var obj = FindObjectOfType<GenerateAsteroids> ();
        var objEnemis = FindObjectOfType<SpawnEnemis>();
		while (true) {

			if (AsteroidSpawnStart != null)
				AsteroidSpawnStart.Invoke (CurrentSpawnNumber);

			obj.AsteroidLevel = CurrentSpawnNumber;
			obj.Spawning = true;

            yield return new WaitForSeconds(2f);
            objEnemis.EnemisLevel = CurrentSpawnNumber;
            objEnemis.Spawning = true;

			yield return new WaitForSeconds (40f);
           
			obj.Spawning = false;
            objEnemis.Spawning = false;

            //if(CurrentSpawnNumber==5)
            //{
            //    yield return new WaitForSeconds(1f);

            //    audioSource.Play();

            //    yield return new WaitForSeconds(3f);
            //    var boss=Instantiate(Boos0bject);
            //    yield return new WaitForSeconds(1f);
            //    boss.GetComponent<BossGun>().enabled = true;

            //    var Obj = GameObject.FindWithTag("Boss");
            //    yield return new WaitUntil(() => Obj == null);
            //    if(Obj==null)
            //    {
            //        audioSource.Stop();
            //    }
            //}

            yield return new WaitForSeconds(2f);

            if (AsteroidSpawnEnd != null)
				AsteroidSpawnEnd.Invoke (CurrentSpawnNumber);

			yield return new WaitForSeconds (5f);

            CurrentSpawnNumber+=1;

            if(FindObjectOfType<GenerateAsteroids>().SpawnTime>0)
            {
                FindObjectOfType<GenerateAsteroids>().SpawnTime -= 0.1f;
            }

            if(FindObjectOfType<SpawnEnemis>().SpawnTime >0)
            {
                FindObjectOfType<SpawnEnemis>().SpawnTime -= 0.5f;
            }

        }

	}
   
}
